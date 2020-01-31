$(document).ready(function () {
    //for language select lang and dinamicly generating category select-option by lang id
    $(".forcategory").click(function () {
        let selectedVal = $(this).find(':selected').val();
        if (selectedVal > 0) {
            $.getJSON("/manage/blog/GetCetgoryByLangId?langId=" + selectedVal, function (data) {
                console.log(data);
                let forajaxcotegory = $(".forajaxcotegory");
                if (data.status === 200) {
                    forajaxcotegory.empty();
                    $.each(data.categories, function (key, item) {
                        let opt = ``;
                        opt += `<option class="option" value="${item.Id}">${item.Name}</option>`;

                        forajaxcotegory.append(opt);
                    });
                }
            });
        }
    });
});