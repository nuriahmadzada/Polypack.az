/*
| ----------------------------------------------------------------------------------
| TABLE OF CONTENT
| ----------------------------------------------------------------------------------
	1. Setting
    2. Icon Hovered
	3. Waypoint Animated
	4. Price Range
	5. Camera Slider
	6. Scroll Top
	7. Carousels All
	8. Paralax   
	9. Slider Product
    10. Flickr
	11. Fancybox
	12.  Contact  Form
*/


$(document).ready(function() {

    $(window).scroll(function () {
        if ($("html").scrollTop() >= 70) {
            $(".fixtop").addClass("fixed-top").css("box-shadow", "0 0 5px grey");
            $(".fixtop").addClass("fixtopbg");
        } else {
            $(".fixtop").removeClass("fixed-top").css("box-shadow", "0 0 0px grey");
            $(".fixtop").removeClass("fixtopbg");
        }
    });

    $('#nav-menu').onePageNav({
        currentClass: 'current',
        changeHash: false,
        scrollSpeed: 1500,
        scrollThreshold: 0.5,
        filter: '',
        easing: 'swing',
        begin: function() {
        },
        end: function() {
        },
        scrollChange: function($currentListItem) {
        }
    });

    "use strict";

    /////////////////////////////////////////////////////////////////
    // SETTING
    /////////////////////////////////////////////////////////////////

    var windowHeight = $(window).height();
    var windowWidth = $(window).width();
	

	
	$('ul li:last-child').addClass('li-last');
	
	
   var windowWidth = $(window).width();
        var tabletWidth = 767;
        var mobileWidth = 640;
	
	
	
	    /////////////////////////////////////
        //  BX CAROUSELS
        /////////////////////////////////////
		
		
		function carouselReload (){
	

													
$(".bxslider").each(function (i) {


  var widthslides = $(this).data("width-slides");
  var marginslides = $(this).data("margin-slides");
  var autoslides = $(this).data("auto-slides");
  var moveslides = $(this).data("move-slides");
  var infiniteslides = $(this).data("infinite-slides");
  
   var maxslides = $(this).data("max-slides");
   var minslides = $(this).data("min-slides");
			   
           

 $(this).bxSlider({
                slideWidth: widthslides ,
                minSlides: minslides,
                maxSlides: maxslides,
                slideMargin: marginslides,
                auto: false,
                moveSlides: moveslides,
                infiniteLoop: false,
				 hideControlOnEnd: true
            });


   $('.bx-next').html(' <i class="fa fa-angle-right"></i>')
    $('.bx-prev').html(' <i class="fa fa-angle-left"></i>')
			
});

		}



  carouselReload ();



    /////////////////////////////////////
    //  Zoom Images
    /////////////////////////////////////

    $("a.magnific").magnificPopup({
        type: 'image'
    });
	
	 $("a.prettyphoto").prettyPhoto();



        ////////////////////////////////////////////   
        // CAROUSEL PRODUCTS
        ///////////////////////////////////////////  



        if ($('#slider-product').length > 0) {


            $('#carousel').flexslider({
                animation: "slide",
                controlNav: false,
                animationLoop: false,
                slideshow: false,
                itemWidth: 105,
                itemMargin: 4,
                asNavFor: '#slider-product'
            });

            $('#slider-product').flexslider({
                animation: "slide",
                controlNav: false,
                animationLoop: false,
                slideshow: false,
                sync: "#carousel"
            });


        }
		
		

	
	  ////////////////////////////////////////////  
    // PARALAX
    ///////////////////////////////////////////  

    $(window).scroll(function(e) {
        parallax();

    });

    function parallax() {
        var scrolled = $(window).scrollTop();
        $('.bg-section').css('top', -(scrolled * 0.3) + 'px');
    }



	
	
	

    if (windowWidth < mobileWidth) {


        /////////////////////////////////////
        //  Disable Mobile Animated
        /////////////////////////////////////


        $("body").removeClass("animated-css");




    }


    $('.animated-css .animated:not(.animation-done)').waypoint(function() {



        var animation = $(this).data('animation');

        $(this).addClass('animation-done').addClass(animation);

    }, {
        triggerOnce: true,
        offset: '90%'
    });



		


	
	  ////////////////////////////////////////////  
    // HOME SLIDER
    ///////////////////////////////////////////  

    if ($('#iview').length > 0) {


        $('#iview').iView({
            pauseTime: 6000,
            pauseOnHover: false,
            directionNavHoverOpacity: 0,
            timer: "Bar",
            timerDiameter: "20%",
            timerPadding: 0,
            timerStroke: 0,
            timerBarStroke: 0,
            timerColor: "#FFF",
            timerPosition: "bottom-right",
            nextLabel: "",
            previousLabel: "",
        });


    }



    /////////////////////////////////////////////////////////////////
    //   Dropdown Menu Fade 
    /////////////////////////////////////////////////////////////////
	
	
		  
	 

	

    $(".dropdown").hover(            
        function() {
            $('.dropdown-menu', this).stop( true, true ).slideDown("fast");
            $(this).toggleClass('open');        
        },
        function() {
            $('.dropdown-menu', this).stop( true, true ).slideUp("fast");
            $(this).toggleClass('open');       
        }
    );


    $(".yamm .navbar-nav>li").hover(
        function() { $('.dropdown-menu', this).fadeIn("fast");
        },
        function() { $('.dropdown-menu', this).fadeOut("fast");
    });




        window.prettyPrint && prettyPrint()
        $(document).on('click', '.yamm .dropdown-menu', function(e) {
          e.stopPropagation()
        })




    //////////////////////////////
    // Animated Entrances
    //////////////////////////////



    if (windowWidth > 1200) {


        $(window).scroll(function() {
            $('.animatedEntrance').each(function() {
                var imagePos = $(this).offset().top;

                var topOfWindow = $(window).scrollTop();
                if (imagePos < topOfWindow + 400) {
                    $(this).addClass("slideUp"); // slideUp, slideDown, slideLeft, slideRight, slideExpandUp, expandUp, fadeIn, expandOpen, bigEntrance, hatch
                }
            });
        });

    }





    /////////////////////////////////////
    //  SCROLL TOP
    /////////////////////////////////////


    if ($('body').length) {
        $(window).on('scroll', function() {
            var winH = $(window).scrollTop();

            if (winH > 500) {
                $(".scroll-top").addClass('scroll-top-view');
            } else {
                $(".scroll-top").removeClass('scroll-top-view');
            }
        });
    }


    $('.scroll-top').click(function(event) {
        event.preventDefault();

        $('html, body').animate({
            scrollTop: 0
        }, 300);
    });




    /////////////////////////////////////////////////////////////////
    //PRICE RANGE
    /////////////////////////////////////////////////////////////////


    if ($('#slider-start').length > 0) {


        $("#slider-start").noUiSlider({
            start: [20, 80],
            range: {
                'min': [0],
                'max': [100]
            }
        });

    }

    /////////////////////////////////////
    //  Chars Start
    /////////////////////////////////////


    if ($('body').length) {
        $(window).on('scroll', function() {
            var winH = $(window).scrollTop();

            $('.featured-item-simple-icon').waypoint(function() {
                $('.chart').each(function() {
                    CharsStart();
                });
            }, {
                offset: '80%'
            });


        });
    }



    function CharsStart() {


        $('.chart').easyPieChart({

            barColor: false,
            trackColor: false,
            scaleColor: false,
            scaleLength: false,
            lineCap: false,
            lineWidth: false,
            size: false,
            animate: 7000,


            onStep: function(from, to, percent) {

                $(this.el).find('.percent').text(Math.round(percent));



            }
        });

    }
	
	
	
	
	

});

