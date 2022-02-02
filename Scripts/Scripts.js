/// <reference path="jquery-3.4.1.min.js" />
/// <reference path="notify.min.js" />


jQuery(document).ready(function ($) {
    $('#loaderbody').addClass('hide');

    $(document).bind('ajaxStart', function () {
        $('#loaderbody').removeClass('hide');
    }).bind('ajaxStop', function () {
        $('#loaderbody').addClass('hide');
    });
});

function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}

function jQueryAjaxPost(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            success: function (response) {
                if (response.success) {
                    $("~/Views/Books/Index.cshtml").html(response.html);
                    refreshAddNewPage($(form.attr('data-resetUrl')));
                    $.notify(response.message, "success");
                }
                else {
                    $.notify(response.message, "error");
                }
            }
        }
        if ($(form).attr('enctype') == "multipart/form-data") {
            ajaxConfig["contentType"] = false;
            ajaxConfig["processData"] = false;
        }
        $.ajax(ajaxConfig);
    }
    return false;
}

function refreshAddNewPage(resetUrl) {
    $.ajax(
        {
            type: 'GET',
            url: resetUrl,
            success: function (response) {
                $("~/Views/Books/Details.cshtml").html(response);
            }
        });
}