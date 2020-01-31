//Kateqoriyalara tklananda alt kateqoriyalarin ve mehsullarin gelmesi ucun
$(document).ready(function () {
    $('.cat-item').click(function () {
        let id = $(this).attr("data-id");
        var area = $(".area");

        if (id !== '') {
            $.ajax({
                url: "/home/getbycategory/" + id,
                method: "GET",
                data: { id: id },
                datatype: "json",
                success: function (data) {

                    area.empty();
                    area.append(`
                        <div class="col-xs-12 col-sm-12 col-md-3 col-lg-3">
                            <div class="widget widget-category">
                              <h3 class="widget-title"><span><i class="fa flaticon-wrench44"></i>Çeşidlər</span></h3>
                              <div class="block_content">
                                <ul class="category-list unstyled clearfix">
                                </ul>
                              </div>
                            </div>
                        </div>

                                <div class="col-sm-6 col-md-9">
                                    <section class="main-content" role="main">
                                        <div class="catalog-grid">
                                            <ul class="product-grid">
                                                
                                            </ul>
                                        </div>
                                    </section>
                                </div>
                    `);


                    var subcats = $(".category-list");
                    var areas = $(".product-grid");
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].Products) {
                   
                                subcats.append(`
                                        <li><a class="pro" id="` + data[i].SubcatId + `">` + data[i].SubcatName + `</a></li>
                                    `);

                            
                            for (j = 0; j < data[i].Products.length; j++) {
                                areas.append(`
                                        <div class="col-sm-6 col-md-6 col-lg-4">
                                                <a data-toggle="modal" data-target="#modal-`+ i + `">
                                                  <div class="img_section1">
                                                       <img src="/Uploads/`+ data[i].Products[j].Photo + `" alt="` + data[i].Products[j].Name + `">
                                                       <p>` + data[i].Products[j].Name + `</p>
                                                     
                                                  </div>
                                                </a>

<div class="modal fade bd-example-modal-lg" id="modal-`+ i + `" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
           
            <div class="modal-body" style="text-align: left;">
  <h2 class="text-center our-color mb-3">`+ data[i].Products[j].Name + `</h2>
                 
              
                 <p><img class="float-left mr-4 mb-3 modal-picture" src="/Uploads/`+ data[i].Products[j].Photo + `" alt="` + data[i].Products[j].Name + `"><span style="font-size: 16px;"> ` + data[i].Products[j].Desc + `</span></p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-info" data-dismiss="modal">Bağla</button>
            </div>
        </div>
    </div>
</div>
                                            </div>
                    `);
                                
                                
                                }
                        }

                        else {
                            subcats.empty();
                            subcats.append(`
                                <li>Bu məhsula dair heç bir alt kateqoriya yoxdur</li>
                            `);
                            var areas = $(".product-grid");
                            areas.append(`
                                        <div class="col-sm-6 col-md-6 col-lg-4">
                                                <a data-toggle="modal" data-target="#modal-`+ i + `">
                                                  <div class="img_section1">
                                                       <img src="/Uploads/`+ data[i].Photo + `" alt="` + data[i].Name + `">
                                                       <p>` + data[i].Name + `</p>
                                                     
                                                  </div>
                                                </a>

<div class="modal fade bd-example-modal-lg" id="modal-`+ i + `" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
           
            <div class="modal-body" style="text-align: left;">
  <h2 class="text-center our-color mb-3">`+ data[i].Name + `</h2>
                 
              
                 <p><img class="float-left mr-4 mb-3 modal-picture" src="/Uploads/`+ data[i].Photo + `" alt="` + data[i].Name + `"><span style="font-size: 16px;"> ` + data[i].Desc + `</span></p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-info" data-dismiss="modal">Bağla</button>
            </div>
        </div>
    </div>
</div>
                                            </div>
                    `);
                       
                             
                        }

                    }


                    var back = $("<a></a>");
                    back.text("Geriyə Qayıt");
                    back.attr("class", "back");
                    back.attr("id");
                    subcats.append(back);

                    
                }
            });
        }
    });
});

// Her hansi bir alt kateqoriyaya tklananda Id-sine uyghun mehsullarin gelmesi uchun
$(document).on('click', '.pro', function () {
    let id = $(this).attr("id");
    var area = $(".area");

    $.ajax({
        url: "/home/getbyproducts/" + id,
        type: "get",
        datatype: "json",
        success: function (response) {
            if (id !== '') {
                area.empty();
                area.append(`
                     <div class="col-xs-12 col-sm-12 col-md-3 col-lg-3">
                            <div class="widget widget-category">
                              <h3 class="widget-title"><span><i class="fa flaticon-wrench44"></i>Çeşidlər</span></h3>
                              <div class="block_content">
                                <ul class="category-list unstyled clearfix">
                                </ul>
                              </div>
                            </div>
                        </div>

                                <div class="col-sm-6 col-md-9">
                                    <section class="main-content" role="main">
                                        <div class="catalog-grid">
                                            <ul class="product-grid">
                                                
                                            </ul>
                                        </div>
                                    </section>
                                </div>   
                    `);

                var areas = $(".product-grid");
                var subcats = $(".category-list");

            
                    for (k = 0; k < response[0].Category.length; k++) {
                   
                        subcats.append(`
                            <li><a class="pro" id="` + response[0].Category[k].Id + `">` + response[0].Category[k].Name + `</a></li>
                        `);
                    }


                for (i = 0; i < response.length; i++) {
                    console.log("OK");
                    areas.append(`
                                        <div class="col-sm-6 col-md-6 col-lg-4">
                                                <a data-toggle="modal" data-target="#modal-`+ i +`">
                                                  <div class="img_section1">
                                                       <img src="/Uploads/`+ response[i].Photo + `" alt="` + response[i].Name + `">
                                                       <p>` + response[i].Name + `</p>
                                                     
                                                  </div>
                                                </a>

<div class="modal fade bd-example-modal-lg" id="modal-`+ i +`" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
           
            <div class="modal-body" style="text-align: left;">
  <h2 class="text-center our-color mb-3">`+ response[i].Name +`</h2>
                 
              
                 <p><img class="float-left mr-4 mb-3 modal-picture" src="/Uploads/`+ response[i].Photo + `" alt="` + response[i].Name + `"><span style="font-size: 16px;"> `+response[i].Desc +`</span></p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-info" data-dismiss="modal">Bağla</button>
            </div>
        </div>
    </div>
</div>
                                            </div>
                    `);
                }
                var back = $("<a></a>");
                back.text("Geriyə Qayıt");
                back.attr("class", "back");
                subcats.append(back);
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
});

// Kateqoriyalar bolmesine qayitmaq uchun
$(document).on('click', '.back , .to-back', function () {
    var area = $(".area");
    $.ajax({
        url: "/home/getcategories/",
        type: "get",
        dataType: "json",
        success: function (list) {
            area.empty();
            for (i = 0; i < list.length; i++)
            {
                area.append(`
                        <div class="col-sm-6 col-md-6 col-lg-4">
                            <a class="cat-items" data-id="` + list[i].CategoryId + `">
                                                    <div class="img_section">
                                                    <img src="/Uploads/` + list[i].Picture + `" alt="">
                                                        <p>` + list[i].Name + `</p>
                                                    </div>
                                                </a>
                        </div>
                    `);

             

            }
        },
        error: function (error) {
            console.log(error);
        }
    });
});

//// Yeniden her hansi kateqoriyaya tklananda alt kateqoriya ve mehsullarin gelmesi uchun
// document.ready ve document.on ferqlerine gore.
$(document).on('click', '.cat-items', function () {
    let id = $(this).attr("data-id");
    var area = $(".area");

    if (id !== '') {
        $.ajax({
            url: "/home/getbycategory/" + id,
            method: "GET",
            data: { id: id },
            datatype: "json",
            success: function (data) {

                area.empty();
                area.append(`
                        <div class="col-xs-12 col-sm-12 col-md-3 col-lg-3">
                            <div class="widget widget-category">
                              <h3 class="widget-title"><span><i class="fa flaticon-wrench44"></i>Çeşidlər</span></h3>
                              <div class="block_content">
                                <ul class="category-list unstyled clearfix">
                                </ul>
                              </div>
                            </div>
                        </div>

                                <div class="col-sm-6 col-md-9">
                                    <section class="main-content" role="main">
                                        <div class="catalog-grid">
                                            <ul class="product-grid">
                                                
                                            </ul>
                                        </div>
                                    </section>
                                </div>
                    `);


                var subcats = $(".category-list");
                var areas = $(".product-grid");
                for (var i = 0; i < data.length; i++) {
                    if (data[i].Products) {
                  
                        subcats.append(`
                                        <li><a class="pro" id="` + data[i].SubcatId + `">` + data[i].SubcatName + `</a></li>
                                    `);


                        for (j = 0; j < data[i].Products.length; j++) {
                            areas.append(`
                                        <div class="col-sm-6 col-md-6 col-lg-4">
                                                <a data-toggle="modal" data-target="#modal-`+ i + `">
                                                  <div class="img_section1">
                                                       <img src="/Uploads/`+ data[i].Products[j].Photo + `" alt="` + data[i].Products[j].Name + `">
                                                       <p>` + data[i].Products[j].Name + `</p>
                                                     
                                                  </div>
                                                </a>

<div class="modal fade bd-example-modal-lg" id="modal-`+ i + `" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
           
            <div class="modal-body" style="text-align: left;">
  <h2 class="text-center our-color mb-3">`+ data[i].Products[j].Name + `</h2>
                 
              
                 <p><img class="float-left mr-4 mb-3 modal-picture" src="/Uploads/`+ data[i].Products[j].Photo + `" alt="` + data[i].Products[j].Name + `"><span style="font-size: 16px;"> ` + data[i].Products[j].Desc + `</span></p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-info" data-dismiss="modal">Bağla</button>
            </div>
        </div>
    </div>
</div>
                                            </div>
                    `);
                       


                        }
                    }

                    else {
                
                        subcats.empty();
                        subcats.append(`
                                <li>Bu məhsula dair heç bir alt kateqoriya yoxdur</li>
                            `);
                        var areas = $(".product-grid");
                        areas.append(`
                                        <div class="col-sm-6 col-md-6 col-lg-4">
                                                <a data-toggle="modal" data-target="#modal-`+ i + `">
                                                  <div class="img_section1">
                                                       <img src="/Uploads/`+ data[i].Photo + `" alt="` + data[i].Name + `">
                                                       <p>` + data[i].Name + `</p>
                                                     
                                                  </div>
                                                </a>

<div class="modal fade bd-example-modal-lg" id="modal-`+ i + `" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
           
            <div class="modal-body" style="text-align: left;">
  <h2 class="text-center our-color mb-3">`+ data[i].Name + `</h2>
                 
              
                 <p><img class="float-left mr-4 mb-3 modal-picture" src="/Uploads/`+ data[i].Photo + `" alt="` + data[i].Name + `"><span style="font-size: 16px;"> ` + data[i].Desc + `</span></p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-info" data-dismiss="modal">Bağla</button>
            </div>
        </div>
    </div>
</div>
                                            </div>
                    `);
                       
                    }

                }
                var back = $("<a></a>");
                back.text("Geriyə Qayıt");
                back.attr("class", "back");
                back.attr("id");
                subcats.append(back);
            }
        });
    }
    });


// LOAD MORE
//$(document).ready(function () {
//    $('.load-more').click(function () {
//        var area = $(".area");
//            $.ajax({
//                url: "/home/getlist",
//                type: "get",
//                dataType: "json",
//                success: function (response) {

//                    for (i = 0; i < response.data.length; i++) {
//                        console.log(response.data[i]);
//                        area.append(`
//                            <div class="col-sm-6 col-md-6 col-lg-4">
//                                <a class="cat-items" data-id="` + response.data[i].Id + `">
//                                    <div class="img_section">

//                                        <img src="/Uploads/` + response.data[i].Photo + `" alt="">
//                                        <p>` + response.data[i].Name + `</p>

//                                    </div>
//                                </a>
//                            </div>
//                        `);
//                    }

//                },
//                error: function (err) {

//                }
//            });
//    });
//});


