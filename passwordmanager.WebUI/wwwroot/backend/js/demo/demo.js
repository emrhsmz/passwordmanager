$(document).ready(function () {

    jQuery(document).ready(function ($) {
        $(".tableList").click(function () {
            window.location.href = $(this).data('href');
        });
    });
});