$(document).ready(function () {
    //Определяет поведение меню слева, возникающее при уменьшении экрана
    let menuHandler = function () {
        $(".navbar-burger").toggleClass("is-active");
        $("#navbarMenu").toggleClass("is-active");
        $("#basicNavBarMenu").toggleClass("is-hidden");
        $("#fullNavBarMenu").toggleClass("is-hidden");
    }
    $(".navbar-burger").on('click', function () {
        let isClick = true;
        menuHandler();
        $(window).resize(function () {

            console.log(isClick);
            if (isClick) {
                menuHandler();
            }
            isClick = false;
        });
    });


    //Поведение Card в зависимости от изменения разрешения экрана
    let resizeHandler = function () {
        if ($(window).width() <= 768) {
            $('.card-content').addClass('is-hidden');
            $('.column-card').removeClass().addClass('column is-full column-card');
        }
        if ($(window).width() >= 769 && $(window).width() <= 1023) {
            $('.card-content').removeClass('is-hidden');
            $('.column-card').removeClass().addClass('column is-half column-card');
        }
        if ($(window).width() >= 1024 && $(window).width() <= 1215) {
            $('.card-content').removeClass('is-hidden');
            $('.column-card').removeClass().addClass('column is-one-third column-card');
        }
        if ($(window).width() >= 1216) {
            $('.card-content').removeClass('is-hidden');
            $('.column-card').removeClass().addClass('column is-one-quarter column-card');
        }
    }
    $(window).on('load resize', resizeHandler);

    $('.blockquote-style').fadeIn(2000);

    $(".work-list-dropdown").hide();
    $('.click-element').click(function () {
        $(this).next().slideToggle();
    });

    ////Подсчет символов и запрет enter в textarea
    $('textarea').keypress(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
        }
    });

    //Ввод телефонного номера
    let telInput = $('input[type="tel"]');
    telInput.each(function () {
        $('.phone-number').mask("+7 (999) 999-99-99");
    });

    //Dropdown
    $(".dropdown").click(function () {
        $(this).toggleClass("is-active");
    });

    //настройка дат
    $('#datepicker').datepicker({
        minDate: new Date(),
        minHours: 9,
        maxHours: 18
    });

    //Подгрузка списка округов/районов, населенных пунктов, улиц 
    $('#Territory').change(function () {
        $.ajax({
            type: 'POST',
            url: companyProject.Urls.GetPartOfAddress,
            data: { parameters: ["District"]},
            success: function(result) {
                $('#District').html(result);
                $('#District').change(function() {
                    var selectedDistrict = $('#District option:selected').val();
                    $.ajax({
                        type: "POST",
                        url: companyProject.Urls.GetPartOfAddress ,
                        data: { parameters: ["PopulatedArea", selectedDistrict]},
                        success: function (result) {
                            $('#PopulatedArea').html(result);
                            $('#PopulatedArea').change(function() {
                                var selectPopulatedArea = $('#PopulatedArea option:selected').val();
                                $.ajax({
                                    type: 'POST',
                                    url: companyProject.Urls.GetPartOfAddress,
                                    data: { parameters: ["Street", selectPopulatedArea] },
                                    success: function (result) {
                                        $('#Street').html(result);
                                    }
                                });
                            });
                        }
                    });
                });
            }
        });
    });

    //настройка дат
    $('#VisitTime').datepicker({
        minDate: new Date(),
        minHours: 9,
        maxHours: 18
    });

    $("#make-order input[name='IsAdoptedPrivacyPolicy']")[0].checked = true;
    $("#checking-data").on("click", CheckMakeOrderForm);

    //Перезагрузка страницы с кнопки "Очистить"
    $("#reset-button").on("click",
        function() {
            location.reload();
        });
});

function CheckFormField() {
    var custimerName = !!($("#CustomerName").val());
    var phoneNumber = !!($("#PhoneNumber").val());
    var territory = !!($("#Territory").val());
    var district = !!($("#District").val());
    var populatedArea = !!($("#PopulatedArea").val());
    var houseNumber = !!($("#PopulatedArea").val());
    var typeOfFailure = !!($("#TypeOfFailure").val());
    if (!custimerName ||
        !phoneNumber ||
        !territory ||
        !district ||
        !populatedArea ||
        !houseNumber ||
        !typeOfFailure
    )
        return false;
    else return true;
}

function SuccessSendForm(data) {
    if (!JSON.parse(data)) {
        $.toast({
            text: "Сообщение не отправлено. Необходимо принять \"Политику конфиденциальности\".", // Text that is to be shown in the toast
            heading: 'Ошибка',
            icon: 'error',
            showHideTransition: 'fade',
            allowToastClose: true,
            hideAfter: 3000,
            stack: false,
            position: 'bottom-right',
            textAlign: 'left',
            loader: false
        });
    } else {
        $.toast({
            text: "Сообщение успешно отправлено.",
            heading: 'Успех',
            icon: 'success',
            showHideTransition: 'fade',
            allowToastClose: true,
            hideAfter: 3000,
            stack: false,
            position: 'bottom-right',
            textAlign: 'left',
            loader: false
        });
        $('button[name="submit-form"]').attr('disabled', true);
    }
}
function FailureSendForm(data) {
    $.toast({
        text: "Внутренняя ошибка. Сообщение не отправлено.",
        heading: 'Ошибка',
        icon: 'error',
        showHideTransition: 'fade',
        allowToastClose: true,
        hideAfter: 3000,
        stack: false,
        position: 'bottom-right',
        textAlign: 'left',
        loader: false
        //loaderBg: '#9EC600'
    });
}

function CheckMakeOrderForm(event) {
    if (!CheckFormField())
        return;
    var privacyPolicyIsChecked = $('#IsAdoptedPrivacyPolicy').is(':checked');
    if (!Boolean(privacyPolicyIsChecked)) {
        event.preventDefault();
        $.toast({
            text:
                "Необходимо принять \"Политику конфиденциальности\".",
            heading: 'Ошибка',
            icon: 'error',
            showHideTransition: 'fade',
            allowToastClose: true,
            hideAfter: 3000,
            stack: false,
            position: 'bottom-right',
            textAlign: 'left',
            loader: false
        });
    } else {
        $.ajaxSetup({
            cache: false
        });
        event.preventDefault();
        $.ajax({
            type: "POST",
            url: companyProject.Urls.MakeOrderConfirm,
            data: $('#make-order').serializeArray(),
            success: function (data) {
                
                $("#modalContent").html(data);
                $(".modal").addClass("is-active");
            }
        });
    }
}
function Failure() {
    $.toast({
        text: "Внутренняя ошибка. Пожалуйста, попробуйте позднее",
        heading: 'Ошибка',
        icon: 'error',
        showHideTransition: 'fade',
        allowToastClose: true,
        hideAfter: 3000,
        stack: false,
        position: 'bottom-right',
        textAlign: 'left',
        loader: false
        //loaderBg: '#9EC600'
    });
}










