$(document).ready(function() {
    $("[data-path]").click(function() {
        const element = this;

        const foodId = $(".modalFoodItem_Id").val();

        const path = $(element).data("path");
        const resource = $(element).data("resource");
        const redirectUrl = `${path}/${resource}`;

        window.location.href = new URL(`${redirectUrl}/${foodId}`, window.location.href).href;
    });
    $(".make-requisition").click(function() {
        const element = this;

        // Modal data
        const modalTitle = $(element).data("modalTitle");
        const modalDonorText = $(element).data("modalDonorText");
        const modalCloseText = $(element).data("modalCloseText");
        const modalIsMinimal = $(element).data("modalIsMinimal");

        $("#requisitionFoodModalTitle").text(modalTitle);
        $("#requisitionFoodModalDonorText").text(modalDonorText);
        $("#requisitionFoodModalCloseText").text(modalCloseText);
        
        $("[data-alere-dynamic-display]").removeClass("collapse");
        $("[data-path]").addClass("collapse");

        if(modalIsMinimal) {
            $("[data-alere-dynamic-display]").addClass("collapse");
            $("[data-path]").removeClass("collapse");
        }

        // Food data
        const foodId = $(element).data("food-id");
        const foodName = $(element).data("food-name");
        const foodHasManufacturedDate = ($(element).data("food-has-manufactured-date") === true);
        const foodManufacturedAt = $(element).data("food-manufactured-at");
        const foodExpireAt = $(element).data("food-expire-at");
        const foodIsPerishable = ($(element).data("food-is-perishable") === true);
        const foodType = $(element).data("food-type");
        const foodDescription = $(element).data("food-description");

        $(".modalFoodItem_Id").val(parseInt(foodId));
        $(".modalFoodItem_Name").text(foodName);
        $(".modalFoodItem_ExpireAt").text(foodExpireAt);
        $(".modalFoodItem_IsPerishable").text(foodIsPerishable ? "Sim" : "N??o");
        $(".modalFoodItem_Type").text(foodType);
        $(".modalFoodItem_Description").text(foodDescription);

        // Donor data
        const donorName = $(element).data("donor-name");
        const donorContact = $(element).data("donor-contact");
        const donorLocation = $(element).data("donor-location");
        const donorId = $(element).data("donor-id");

        $(".modalDonorItem_Name").text(donorName);
        $(".modalDonorItem_Contact").text(donorContact);
        $(".modalDonorItem_Location").text(donorLocation);
        $(".modalDonorItem_Id").val(parseInt(donorId));

        if(!foodHasManufacturedDate) {
            $("#modalFoodItem_HasManufacturedDate").addClass("d-none");
            return;
        }

        $(".modalFoodItem_ManufacturedAt").text(foodManufacturedAt);
        $("#modalFoodItem_HasManufacturedDate").removeClass("d-none");
    });
});