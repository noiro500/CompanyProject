var _this = this;
$(function () {
    //Определяет поведение меню слева, возникающее при уменьшении экрана
    var menuHandler = function () {
        $(".navbar-burger").toggleClass("is-active");
        $("#navbarMenu").toggleClass("is-active");
        $("#basicNavBarMenu").toggleClass("is-hidden");
        $("#fullNavBarMenu").toggleClass("is-hidden");
    };
    $(".navbar-burger").on("click", function () {
        var isClick = true;
        menuHandler();
        $(window).resize(function () {
            console.log(isClick);
            if (isClick) {
                menuHandler();
            }
            isClick = false;
        });
    });
    $(".blockquote-style").fadeIn(2000);
    $(".work-list-dropdown").hide();
    $(".click-element").click(function () {
        $(_this).next().slideToggle();
    });
    ////Подсчет символов и запрет enter в textarea
    $("textarea").keypress(function (event) {
        if (event.keyCode === 13) {
            event.preventDefault();
        }
    });
    //Ввод телефонного номера
    var telInput = $('input[type="tel"]');
    telInput.each(function () {
        $(".phone-number").mask("+7 (999) 999-99-99");
    });
    //Dropdown
    $(".dropdown").click(function () {
        $(_this).toggleClass("is-active");
    });
    var addressDataService = "http://localhost:8010/gateway/v1/Address/GetPartOfAddress";
    //Подгрузка списка округов/районов, населенных пунктов, улиц 
    $("#AddressData_Territory").change(function () {
        $.ajax({
            type: "POST",
            url: addressDataService,
            dataType: "html",
            data: { parameters: ["District"] },
            success: function (result) {
                $("#AddressData_District").html(result);
                $("#AddressData_District").change(function () {
                    var selectedDistrict = $("#AddressData_District option:selected").val();
                    $.ajax({
                        type: "POST",
                        url: addressDataService,
                        dataType: "html",
                        data: { parameters: ["PopulatedArea", selectedDistrict] },
                        success: function (result) {
                            $("#AddressData_PopulatedArea").html(result);
                            $("#AddressData_PopulatedArea").change(function () {
                                var selectPopulatedArea = $("#AddressData_PopulatedArea option:selected").val();
                                $.ajax({
                                    type: "POST",
                                    url: addressDataService,
                                    dataType: "html",
                                    data: { parameters: ["Street", selectPopulatedArea] },
                                    success: function (result) {
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
    var a = $(_this).find("#make-order");
    if (a.length) {
        var input = $("#make-order input[name='IsAdoptedPrivacyPolicy']")[0];
        input.checked = true;
        //$("#make-order input[name='IsAdoptedPrivacyPolicy']")[0].checked = true;
    }
    $("#checking-data").on("click", CheckMakeOrderForm);
});
function CheckFormField() {
    var name = !!($("#Name").val());
    var phoneNumber = !!($("#PhoneNumber").val());
    var territory = !!($("#AddressData_Territory").val());
    var district = !!($("#AddressData_District").val());
    var populatedArea = !!($("#AddressData_PopulatedArea").val());
    var houseNumber = !!($("#AddressData_HouseNumber").val());
    if (!name ||
        !phoneNumber ||
        !territory ||
        !district ||
        !populatedArea ||
        !houseNumber)
        return false;
    else
        return true;
}
function SuccessSendForm(data) {
    var respons = JSON.parse(data);
    //if (respons.parameter === "description") {
    //    $('button[name="submit-form"]').attr('disabled', true);
    //    return;
    //}
    if (respons.parameter === "warning") {
        $.toast(({
            text: "Сообщение не отправлено. Необходимо принять \"Политику конфиденциальности\".",
            heading: "Внимание",
            icon: "warning",
            showHideTransition: "fade",
            allowToastClose: true,
            hideAfter: 3000,
            stack: false,
            position: "bottom-right",
            textAlign: "left",
            loader: false,
            bgColor: "#ff7733"
        }));
    }
    else if (respons.parameter === "ok") {
        $.toast(({
            text: "Сообщение успешно отправлено.",
            heading: "Успех",
            icon: "success",
            showHideTransition: "fade",
            allowToastClose: true,
            hideAfter: 3000,
            stack: false,
            position: "bottom-right",
            textAlign: "left",
            loader: false
        }));
        $('button[name="submit-form"]').attr("disabled", true);
    }
    else if (respons.parameter === "error") {
        FailureSendForm();
    }
}
function FailureSendForm() {
    $.toast(({
        text: "Внутренняя ошибка. Сообщение не отправлено.",
        heading: "Ошибка",
        icon: "error",
        showHideTransition: "fade",
        allowToastClose: true,
        hideAfter: 3000,
        stack: false,
        position: "bottom-right",
        textAlign: "left",
        loader: false
        //loaderBg: '#9EC600'
    }));
}
function CheckMakeOrderForm(event) {
    if (!CheckFormField())
        return;
    var privacyPolicyIsChecked = $("#IsAdoptedPrivacyPolicy").is(":checked");
    if (!Boolean(privacyPolicyIsChecked)) {
        event.preventDefault();
        $.toast(({
            text: "Необходимо принять \"Политику конфиденциальности\".",
            heading: "Ошибка",
            icon: "error",
            showHideTransition: "fade",
            allowToastClose: true,
            hideAfter: 3000,
            stack: false,
            position: "bottom-right",
            textAlign: "left",
            loader: false
        }));
    }
    else {
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
    $.toast(({
        text: "Внутренняя ошибка. Пожалуйста, попробуйте позднее",
        heading: "Ошибка",
        icon: "error",
        showHideTransition: "fade",
        allowToastClose: true,
        hideAfter: 3000,
        stack: false,
        position: "bottom-right",
        textAlign: "left",
        loader: false
        //loaderBg: '#9EC600'
    }));
}
//Работа с модальным окном "Проверьте введенные данные"
var ajaxSuccess = true;
function MakeOrderConfirmModalWindow(param) {
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
