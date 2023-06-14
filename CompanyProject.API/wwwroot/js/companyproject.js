var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
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
        $(window).on("resize", function () {
            if (isClick) {
                menuHandler();
            }
            isClick = false;
        });
    });
    $(".blockquote-style").fadeIn(2000);
    $(".work-list-dropdown").hide();
    $(".click-element").on("click", function () {
        $(_this).next().slideToggle();
    });
    ////Подсчет символов и запрет enter в textarea
    $("textarea").on("keypress", function (event) {
        if (event.key === "Enter") {
            event.preventDefault();
        }
    });
    //Ввод телефонного номера
    var telInput = $('input[type="tel"]');
    telInput.each(function () {
        $(".phone-number").mask("+7 (999) 999-99-99");
    });
    //Dropdown
    $(".dropdown").on("click", function () {
        $(_this).toggleClass("is-active");
    });
    var addressDataService = "http://localhost:8010/gateway/v1/Address/GetPartOfAddress";
    //Подгрузка списка округов/районов, населенных пунктов, улиц 
    $("#AddressData_Territory").on("change", function () {
        $.ajax({
            type: "POST",
            url: addressDataService,
            dataType: "html",
            data: { parameters: ["District"] },
            success: function (result) {
                $("#AddressData_District").html(result);
                $("#AddressData_District").on("change", function () {
                    var selectedDistrict = $("#AddressData_District option:selected").val();
                    $.ajax({
                        type: "POST",
                        url: addressDataService,
                        dataType: "html",
                        data: { parameters: ["PopulatedArea", selectedDistrict] },
                        success: function (result) {
                            $("#AddressData_PopulatedArea").html(result);
                            $("#AddressData_PopulatedArea").on("change", function () {
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
    var checkedId = document.getElementById("IsAdoptedPrivacyPolicy");
    if (checkedId) {
        checkedId.checked = true;
    }
    $("#checking-data").on("click", CheckMakeOrderForm);
});
var generalToastMessage = {
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
    if (respons.parameter === "warning") {
        var warningMessage = __assign(__assign({}, generalToastMessage), { text: "Сообщение не отправлено. Необходимо принять \"Политику конфиденциальности\".", heading: "Внимание", icon: "warning", bgColor: "#ff7733" });
        $.toast(warningMessage);
    }
    else if (respons.parameter === "ok") {
        var successMessage = __assign(__assign({}, generalToastMessage), { text: "Сообщение успешно отправлено.", heading: "Успех", icon: "success", bgColor: "#4FB870" });
        $.toast(successMessage);
        $('button[name="submit-form"]').attr("disabled", true);
    }
    else if (respons.parameter === "error") {
        FailureSendForm();
    }
}
function FailureSendForm() {
    var errorMessage = __assign(__assign({}, generalToastMessage), { text: "Внутренняя ошибка. Сообщение не отправлено.", heading: "Ошибка", icon: "error", bgColor: "#CC0A0A" });
    $.toast(errorMessage);
}
function CheckMakeOrderForm(event) {
    if (!CheckFormField())
        return;
    var privacyPolicyIsChecked = $("#IsAdoptedPrivacyPolicy").is(":checked");
    if (!Boolean(privacyPolicyIsChecked)) {
        event.preventDefault();
        var warningMessage = __assign(__assign({}, generalToastMessage), { text: "Заказ не сформирован. Необходимо принять \"Политику конфиденциальности\".", heading: "Внимание", icon: "warning", bgColor: "#ff7733" });
        $.toast(warningMessage);
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
    var errorMessage = __assign(__assign({}, generalToastMessage), { text: "Внутренняя ошибка.Пожалуйста, попробуйте позднее.", heading: "Ошибка", icon: "error", bgColor: "#CC0A0A" });
    $.toast(errorMessage);
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
