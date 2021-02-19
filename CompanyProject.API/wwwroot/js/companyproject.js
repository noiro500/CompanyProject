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
            whenEnterPressed();
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
    $('#territory').change(function () {
        $.ajax({
            type: 'GET',
            url: companyProject.Urls.GetPartOfAddress + '?parameters=District',
            success: function(result) {
                $('#district-to-replace').html(result);
                $('#district-to-replace').change(function() {
                    var selectedDistrict = $('#district-to-replace option:selected').val();
                    $.ajax({
                        type: 'GET',
                        url: companyProject.Urls.GetPartOfAddress + '?' + '[0]=PopulatedArea' + '&[1]=' + selectedDistrict,
                        success: function (result) {
                            $('#populated-area-to-replace').html(result);
                            $('#populated-area-to-replace').change(function() {
                                var selectPopulatedArea = $('#populated-area-to-replace option:selected').val();
                                $.ajax({
                                    type: 'GET',
                                    url: companyProject.Urls.GetPartOfAddress + '?' + '[0]=Street' + '&[1]=' + selectPopulatedArea,
                                    success: function (result) {
                                        $('#street-to-replace').html(result);
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
    var tomorrow = new Date();

    $('#datepicker').datepicker({
        minDate: new Date(),
        minHours: 9,
        maxHours: 18
    });
    $('#make-order').validate({
        errorClass: "has-text-danger",
        focusCleanup: true,
        rules: {
            CustomerName: {
                required: true
            },
            PhoneNumber: {
                required: true
                }
        },
        messages: {
            CustomerName: {
                required: "Не указано полное имя заказчика"
            },
            PhoneNumber: {
                required: "Не указан номер телефона"
            }
        }
    });

});

function SuccessSendForm(data) {
    //$('button[name="submitForm"]').attr('disabled', true);
    if (!JSON.parse(data)) {
        $.toast({
            text: "Сообщение не отправлено. Необходимо принять Политику конфиденциальности.", // Text that is to be shown in the toast
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








