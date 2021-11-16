$(document).ready(function () {
    $('.make-requisition').click(function () {
        const element = this;

        // Modal data
        const modalActionText = $(element).data('modalActionText');
        $('#requisitionFoodModalTextAction').text(modalActionText);
    });
});
