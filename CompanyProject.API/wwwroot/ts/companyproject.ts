$(() => {
    //Определяет поведение меню слева, возникающее при уменьшении экрана
    const menuHandler = () => {
        $(".navbar-burger").toggleClass("is-active");
        $("#navbarMenu").toggleClass("is-active");
        $("#basicNavBarMenu").toggleClass("is-hidden");
        $("#fullNavBarMenu").toggleClass("is-hidden");
    };
    $(".navbar-burger").on("click", () => {
        let isClick = true;
        menuHandler();
        $(window).on("resize",
            () => {
                if (isClick) {
                    menuHandler();
                }
                isClick = false;
            });
    });

    $(".blockquote-style").fadeIn(2000);

    $(".work-list-dropdown").hide();
    $(".click-element").on("click", (event) =>  {
        $(event.currentTarget).next().slideToggle();
    });

    ////Подсчет символов и запрет enter в textarea
    $("textarea").on("keypress", event => {
        if (event.key === "Enter") {
            event.preventDefault();
        }
    });

    //Ввод телефонного номера
    const telInput = $('input[type="tel"]');
    telInput.each(() => {
        $(".phone-number").mask("+7 (999) 999-99-99");
    });

    $(".dropdown").on("click", (event) => {
        $(event.currentTarget).toggleClass("is-active");
    });

    const addressDataService = "http://localhost:8010/gateway/v1/Address/GetPartOfAddress";
    //Подгрузка списка округов/районов, населенных пунктов, улиц 
    $("#AddressData_Territory").on("change", () => {
        $.ajax({
            type: "POST",
            url: addressDataService,
            dataType: "html",
            data: { parameters: ["District"] },
            success: result => {
                $("#AddressData_District").html(result);
                $("#AddressData_District").on("change", () => {
                    const selectedDistrict = $("#AddressData_District option:selected").val();
                    $.ajax({
                        type: "POST",
                        url: addressDataService,
                        dataType: "html",
                        data: { parameters: ["PopulatedArea", selectedDistrict] },
                        success: result => {
                            $("#AddressData_PopulatedArea").html(result);
                            $("#AddressData_PopulatedArea").on("change", () => {
                                const selectPopulatedArea = $("#AddressData_PopulatedArea option:selected").val();
                                $.ajax({
                                    type: "POST",
                                    url: addressDataService,
                                    dataType: "html",
                                    data: { parameters: ["Street", selectPopulatedArea] },
                                    success: (result) => {
                                        $("#AddressData_Street").html(result);
                                    }
                                });
                            });
                        }
                    });
                });
            }
        });
    });

    const checkedId = document.getElementById("IsAdoptedPrivacyPolicy") as HTMLInputElement;
    if (checkedId) {
        checkedId.checked = true;
    }
    $("#checking-data").on("click", CheckMakeOrderForm);

});

let generalToastMessage: toastOptions = {
    text: "",
    heading: "",
    icon: undefined,
    showHideTransition: "fade",
    allowToastClose: true,
    hideAfter: 3000,
    stack: 0,
    position: "bottom-right",
    textAlign: "left",
    loader: false,
    bgColor: ""
};

function CheckFormField() {
    const name = !!($("#Name").val());
    const phoneNumber = !!($("#PhoneNumber").val());
    const territory = !!($("#AddressData_Territory").val());
    const district = !!($("#AddressData_District").val());
    const populatedArea = !!($("#AddressData_PopulatedArea").val());
    const houseNumber = !!($("#AddressData_HouseNumber").val());
    if (!name ||
        !phoneNumber ||
        !territory ||
        !district ||
        !populatedArea ||
        !houseNumber
    )
        return false;
    else
        return true;
}

function SuccessSendForm(data: string) {
    const respons = JSON.parse(data);
    if (respons.parameter === "warning") {
        let warningMessage = {
            ...generalToastMessage,
            text: "Сообщение не отправлено. Необходимо принять \"Политику конфиденциальности\".",
            heading: "Внимание",
            icon: "warning" as 'warning',
            bgColor: "#ff7733"
        };
        $.toast(warningMessage);

    } else if (respons.parameter === "ok") {
        let successMessage = {
            ...generalToastMessage,
            text: "Сообщение успешно отправлено.",
            heading: "Успех",
            icon: "success" as 'success',
            bgColor: "#4FB870"
        }
        $.toast(successMessage);
        $('button[name="submit-form"]').prop("disabled", true);
    } else if (respons.parameter === "error") {
        FailureSendForm();
    }
}

function FailureSendForm() {
    let errorMessage = {
        ...generalToastMessage,
        text: "Внутренняя ошибка. Сообщение не отправлено.",
        heading: "Ошибка",
        icon: "error" as 'error',
        bgColor: "#CC0A0A"
    }
    $.toast(errorMessage);
}


function CheckMakeOrderForm(event: any) {
    if (!CheckFormField())
        return;
    const privacyPolicyIsChecked = $("#IsAdoptedPrivacyPolicy").is(":checked");
    if (!Boolean(privacyPolicyIsChecked)) {
        event.preventDefault();
        let warningMessage = {
            ...generalToastMessage,
            text: "Заказ не сформирован. Необходимо принять \"Политику конфиденциальности\".",
            heading: "Внимание",
            icon: "warning" as 'warning',
            bgColor: "#ff7733"
        };
        $.toast(warningMessage);
    } else {
        $.ajaxSetup({
            cache: false
        });
        event.preventDefault();
        $.ajax({
            type: "POST",
            url: companyProject.Urls.MakeOrderConfirm,
            data: $("#make-order").serializeArray(),
            success: function (data) {
                $("#modalContent").html(data);
                $(".modal").addClass("is-active");
            }
        });
    }
}

function Failure() {
    //$.toast(({
    //    text: "Внутренняя ошибка. Пожалуйста, попробуйте позднее",
    //    heading: "Ошибка",
    //    icon: "error",
    //    showHideTransition: "fade",
    //    allowToastClose: true,
    //    hideAfter: 3000,
    //    stack: false,
    //    position: "bottom-right",
    //    textAlign: "left",
    //    loader: false
    //    //loaderBg: '#9EC600'
    //}) as any);
    let errorMessage = {
        ...generalToastMessage,
        text: "Внутренняя ошибка.Пожалуйста, попробуйте позднее.",
        heading: "Ошибка",
        icon: "error" as 'error',
        bgColor: "#CC0A0A"
    }
    $.toast(errorMessage);
}

//Работа с модальным окном "Проверьте введенные данные"
let ajaxSuccess = true;

function MakeOrderConfirmModalWindow(param: any) {

    if (param === "makeOrderConfirm") {
        $.ajax({
            type: "POST",
            url: companyProject.Urls.MakeOrderConfirmResult,
            success: function (data) {
                $("#modal-title").text("Заказ принят в работу");
                $("#modal-data").html(data);
                $("#button-close").removeClass("is-loading");
                ajaxSuccess = true;
            },
            beforeSend: function () {
                $("#button-confirm").addClass("is-hidden");
                $("#button-edit").addClass("is-hidden");
                $("#button-close").addClass("is-loading");

            },
            error: function () {
                $("#modal-title").text("Что-то пошло не так");
                $("#modal-data").html("<p>Сожалеем, но во время формирования Вашего заказа " +
                    "произошла непредвиденная ошибка. Пожалуйста, повторите заказ позже.</p>");
                $("#button-close").removeClass("is-loading");
                ajaxSuccess = false;
            }
        });
        return;
    }
    if (param === "edit") {
        $(".modal").removeClass("is-active");
        return;
    }
    if (param === "close") {
        if (ajaxSuccess)
            $(location).attr("href", companyProject.Urls.Index);
        else {
            $(location).attr("href", companyProject.Urls.Error);
            ajaxSuccess = true;
        }
        return;
    }
}