const dateFormat = /^\d{4}-\d{2}-\d{2}$/;

$(document).ready(function () {
    $('#title').focus();

    $('#savePost').click(function (event) {
        event.preventDefault();

        $.get({
            url: '/Post/IsUniqueTitle',
            data: { title: $('#title').val(), id: $('#Id').val() },
            success: function (data) {
                if (!data) {
                    $('#alert-text').text('The title must be unique.');
                    $('#warning').show();
                    return;
                }
                validatePostForm(data);
            }
        });
    });
});

function validatePostForm(isUniqueTitle) {
    if ($('#category').val() === '0') {
        $('#alert-text').text('You must select a category.');
        $('#warning').show();
        return;
    }

    if (!dateFormat.test($('#publicationDate').val())) {
        $('#alert-text').text('The publication date must have the following format: yyyy-mm-dd.');
        $('#warning').show();
        return;
    }

    if (!$('#content').val()) {
        $('#alert-text').text('You must include some content to your post.');
        $('#warning').show();
        return;
    }

    if (isUniqueTitle) {
        $('#warning').hide();
        $('#PostForm').submit();
    }
}
