"use strict";$(document).ready(function(){$("[data-path]").click(function(){var a=$(".modalFoodItem_Id").val(),o=$(this).data("path"),t=$(this).data("resource"),d="".concat(o,"/").concat(t);window.location.href=new URL("".concat(d,"/").concat(a),window.location.href).href}),$(".make-requisition").click(function(){var a=this,o=$(a).data("modalTitle"),t=$(a).data("modalDonorText"),d=$(a).data("modalCloseText"),e=$(a).data("modalIsMinimal");$("#requisitionFoodModalTitle").text(o),$("#requisitionFoodModalDonorText").text(t),$("#requisitionFoodModalCloseText").text(d),$("[data-alere-dynamic-display]").removeClass("collapse"),$("[data-path]").addClass("collapse"),e&&($("[data-alere-dynamic-display]").addClass("collapse"),$("[data-path]").removeClass("collapse"));var l=$(a).data("food-id"),n=$(a).data("food-name"),i=!0===$(a).data("food-has-manufactured-date"),m=$(a).data("food-manufactured-at"),r=$(a).data("food-expire-at"),s=!0===$(a).data("food-is-perishable"),c=$(a).data("food-type"),I=$(a).data("food-description");$(".modalFoodItem_Id").val(parseInt(l)),$(".modalFoodItem_Name").text(n),$(".modalFoodItem_ExpireAt").text(r),$(".modalFoodItem_IsPerishable").text(s?"Sim":"Não"),$(".modalFoodItem_Type").text(c),$(".modalFoodItem_Description").text(I);var u=$(a).data("donor-name"),f=$(a).data("donor-contact"),p=$(a).data("donor-location"),x=$(a).data("donor-id");$(".modalDonorItem_Name").text(u),$(".modalDonorItem_Contact").text(f),$(".modalDonorItem_Location").text(p),$(".modalDonorItem_Id").val(parseInt(x)),i?($(".modalFoodItem_ManufacturedAt").text(m),$("#modalFoodItem_HasManufacturedDate").removeClass("d-none")):$("#modalFoodItem_HasManufacturedDate").addClass("d-none")})});