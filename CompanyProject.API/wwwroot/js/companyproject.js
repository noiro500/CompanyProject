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
        $('#whatsapp-number').mask("+7 (999) 999-99-99");
    });

    //Dropdown
    $(".dropdown").click(function () {
        $(this).toggleClass("is-active");
    });

    $.datepicker.regional['ru'] = {
        closeText: 'Закрыть',
        prevText: 'Предыдущий',
        nextText: 'Следующий',
        currentText: 'Сегодня',
        monthNames: ['Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь', 'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'],
        monthNamesShort: ['Янв', 'Фев', 'Мар', 'Апр', 'Май', 'Июн', 'Июл', 'Авг', 'Сен', 'Окт', 'Ноя', 'Дек'],
        dayNames: ['воскресенье', 'понедельник', 'вторник', 'среда', 'четверг', 'пятница', 'суббота'],
        dayNamesShort: ['вск', 'пнд', 'втр', 'срд', 'чтв', 'птн', 'сбт'],
        dayNamesMin: ['Вс', 'Пн', 'Вт', 'Ср', 'Чт', 'Пт', 'Сб'],
        weekHeader: 'Не',
        dateFormat: 'dd.mm.yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['ru']);

    //Всплывающее окно Toast на политику конфиденциальности
    //$("input[type='checkbox']#privacy-policy").on('change',function() {
    //    if (!$("input[type='checkbox']#privacy-policy").prop('checked')) {
    //        $.toast('Hello');
    //    }
    //});


    //$('.dropdown-trigger').dropdown();

    ////Кнопка возврата вверх
    //var btn = $('#button');
    //$(window).scroll(function() {     
    //    if ($(window).scrollTop() > 100) {
    //        btn.addClass('show');
    //    } else {
    //        btn.removeClass('show');
    //    }
    //});
    //btn.on('click', function(e) {
    //    e.preventDefault();
    //    $('html, body').animate({scrollTop:0}, '300');
    //});

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
        loader: false,
        //loaderBg: '#9EC600'
    });
}








