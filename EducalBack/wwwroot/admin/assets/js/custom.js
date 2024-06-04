
//delete product in edit
$(document).on("click", ".image-card-product .delete-btn", function () {
	let imageId = parseInt($(this).attr("data-id"));
	let courseId = parseInt($(this).attr("data-courseId"));

	let data = { courseId, imageId };

	$.ajax({
		type: "POST",
		url: `/admin/course/deletecourseimage`,
		data: data,
		success: function (response) {
			$(`[data-id=${imageId}]`).closest(".image-card-product").remove();
		},
		error: function (jqXHR, textStatus, errorThrown) {
			console.error('Error:', textStatus, errorThrown);
		}
	});
});


$(document).on("click", ".image-card-product .main-image-btn", function () {
	let imageId = parseInt($(this).attr("data-id"));

	let courseId = parseInt($(this).attr("data-courseId"));

	let data = { courseId, imageId };

	$.ajax({
		type: "POST",
		url: `/admin/course/setmainimage?`,
		data: data,
		success: function (response) {

			$(".is-main-image").removeClass("is-main-image");
			$(`[data-id=${imageId}]`).closest(".image-card-product").find("img").addClass("is-main-image");
			$(".hide-btn").addClass("show-btn").removeClass("hide-btn");

			$(`[data-id=${imageId}]`).closest(".image-card-product").addClass("hide-btn").removeClass("show-btn");

			
		}
	});


})


