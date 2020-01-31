$(document).ready(function () {
    $("select[name = 'CategoryId']").change(function () {
        var categoryId = $(this).val();

        $.ajax({
            url: "/products/getsubcategories/" + categoryId,
            type: "get",
            dataType: "html",
            success: function (response) {
                if (response) {
                    $("select[name = 'SubCategoryId']").html(response);
                }
                else {
                    $("select[name = 'SubCategoryId']").append(`
                        <option disabled selected value="">Bu məhsula dair alt kateqoriya yoxdur</option>
                `);
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    });
});

