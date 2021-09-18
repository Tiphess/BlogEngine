$(document).ready(function () {
    $('#title').focus();

    $('#saveCategory').click(function (event) {
        event.preventDefault();

        $.get({
            url: '/Category/IsUniqueTitle',
            data: { title: $('#title').val(), id: $('#Id').val() },
            success: function (data) {
                if (!data) {
                    $('#alert-text').text('The title must be unique.');
                    $('#warning').show();
                    return;
                }
                $('#CategoryForm').submit();
            }
        });
    });
});