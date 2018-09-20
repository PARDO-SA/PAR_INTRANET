$(document).ready(function () 
{
    $('#registerFormId').validate({
        errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page
        errorElement: '.input_tabla',
        errorPlacement: function (error, e) {
            e.parents('.input_tabla > .tabla_edit').append(error);
        },
        highlight: function (e) {
  
            $(e).closest('.input_tabla').removeClass('has-success has-error').addClass('has-error');
            $(e).closest('.help-block').remove();
        },
        success: function (e) {
            e.closest('.input_tabla').removeClass('has-success has-error');
            e.closest('.help-block').remove();
        },
        rules: {
            'Email': {
                required: true,
                email: true
            }
        },
        messages: {
            'Email': 'Please enter valid email address'
        }
    });
});