// JavaScript Document



// new js
$(document).ready(function(){
  $("#Show-search").click(function(){
    $("#menu-id").hide();
    $("#search-div-id").show();
    
  });
  $("#search-bnt").click(function(){
    $("#menu-id").show();
    $("#search-div-id").hide();
  });
});

$(document).ready(function(){
    $('#fil-group-bn .comonfli').click(function(){
      $('.comonfli').removeClass("active-new2");
      $(this).addClass("active-new2");
  });
});


/*
Created By:
http://html5andbeyond.com/
*/
$(document).ready(function(){

    $('.play-pause-btn').on('click',function(){
     
    if($(this).attr('data-click') == 1) {
    $(this).attr('data-click', 0)
    $('#video')[0].pause();
    } else {
    $(this).attr('data-click', 1)
    $('#video')[0].play();
    }
     
    });

    $(".play-pause-btn").click(function(){
        $(this).toggleClass("main");
      });
    
});


$(document).ready(function(){
    $(".colm").slice(0,9).show();
    $("#seeMore").click(function(e){
      e.preventDefault();
      $(".colm:hidden").slice(0,9).fadeIn("slow");
      
      if($(".colm:hidden").length == 0){
         $("#seeMore").fadeOut("slow");
        }
    });
  })



  $(document).ready(function(){
    $(".crm-new").slice(0,5).show();
    $("#seeMoreo2").click(function(e){
      e.preventDefault();
      $(".crm-new:hidden").slice(0,5).fadeIn("slow");
      
      if($(".crm-new:hidden").length == 0){
         $("#seeMoreo2").fadeOut("slow");
        }
    });
  })




$(document).ready(function() {
    $( window ).scroll(function() {
          var height = $(window).scrollTop();
          if(height >= 100) {
              $('.mn-head').addClass('fixed-menu');
          } else {
              $('.mn-head').removeClass('fixed-menu');
          }
      });
  });
$(document).ready(function(){
    $('.menu-sild').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
	    	dots:false,
        responsive: {
            0: {
                items:1
            },
            600: {
                items:1
            },
            1000: {
                items:4
            }
        }
    })


    $('.marque-slider').owlCarousel({
      loop: true,
      autoplay:true,
      slideTransition: 'linear',
      autoplayTimeout: 3000,
      autoplaySpeed: 3000,
      autoplayHoverPause: true,
      margin: 10,
      nav: false,
      dots:false,
      responsive: {
          0: {
              items:1
          },
          600: {
              items:1
          },
          1000: {
              items:2
          }
      }
    })

    $('.main-news').owlCarousel({
      loop: true,
      margin: 10,
      nav: true,
      dots:false,
      responsive: {
          0: {
              items:1
          },
          600: {
              items:1
          },
          1000: {
              items:1
          }
      }
   })
	
	$('.more-news').owlCarousel({
        
		autoplay:true,
        margin:25,
        nav: true,
		dots:false,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items:1
            },
            820: {
              items:2
            },
            1000: {
                items:2
            },
            1200: {
              items:3
            }
        }
    })

  $('.best-sl-m2').owlCarousel({
      
    autoplay:true,
    margin:25,
    loop:true,
    nav: true,
    dots:false,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items:1
            },
            768: {
              items:2
            },
            1000: {
                items:4
            }
        }
    })

	$('.news-slid').owlCarousel({
        
		autoplay:true,
        nav: false,
		margin: 20,
		dots:true,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items:1
            },
            768: {
              items:2
            },
            1000: {
                items:3
            }
        }
    })

    $('.all-video').owlCarousel({
        
        autoplay:true,
        loop:true,
         nav: false,
        margin: 20,
        dots:false,
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items:2
                },
                1000: {
                    items:6
                }
            }
    })

    $('.mn-listingn').owlCarousel({
        
      autoplay:true,
      loop:true,
       nav: true,
      margin: 20,
      dots:false,
          responsive: {
              0: {
                  items: 1
              },
              600: {
                  items:1
              },
              1000: {
                  items:1
              }
          }
   })
});

// more bn js 

$(document).ready(function () {
    
   
    $('#more-link').click(function () {
      $('#more-div-text').slideToggle("slow");
	  $('#more-link').hide();
    });

	$('#more-link2').click(function () {
		$('#more-div-text2').slideToggle("slow");
		$('#more-link2').hide();
	  });

	$('#more-link3').click(function () {
		$('#more-div-text3').slideToggle("slow");
		$('#more-link3').hide();
	  });
});



  
$(document).ready(function(){
$('.listed-bn ul li a').click(function(){
    $('.listed-bn li a').removeClass("active");
    $(this).addClass("active");
});
});

// wish list js

$(document).ready(function(){
	$(".comon-likke").click(function(){
		$(".comon-likke").toggleClass("short-link");
	});
});


// // video
// $(document).ready(function () {
//   $('.video').parent().click(function () {
//     if($(this).children(".video").get(0).paused){        $(this).children(".video").get(0).play();   $(this).children(".playpause").fadeOut();
//       }else{       $(this).children(".video").get(0).pause();
//     $(this).children(".playpause").fadeIn();
//       }
//   });
// });



//  bank js
$(document).ready(function(){
  $("#customRadio1").click(function(){
    $("#ac-2").hide();
  });
  $("#customRadio1").click(function(){
    $("#ac-1").show();
  });
   $("#customRadio2").click(function(){
    $("#ac-1").hide();
  });
  $("#customRadio2").click(function(){
    $("#ac-2").show();
  });
});



// rating js 


$(document).ready(function () {
	$(".star label").click(function(){
	  $(this).parent().find("label").css({"background-color": "#a2be2d"});
	  $(this).css({"background-color": "#a2be2d"});
	  $(this).nextAll().css({"background-color": "#a2be2d"});
	});
	$(".star label").click(function(){
	  $(this).parent().find(".star label").css({"color": "#bbb"});
	  $(this).css({"color": "#a2be2d"});
	  $(this).nextAll().css({"color": "#a2be2d"});
	  $(this).css({"background-color": "transparent"});
	  $(this).nextAll().css({"background-color": "transparent"});
	});
});
// quantity js

