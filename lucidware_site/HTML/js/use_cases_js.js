//first row of icons and paragraph fade in
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= ($("#fade_check_15").offset().top)) {
	$('.column_pic2').fadeTo(900,1);
	$('.fade_text_1').fadeTo(900,1);
}

});

//second row of icons and paragraph fade in
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= ($("#fade_check_16").offset().top)) {
	$('.column_pic3').fadeTo(900,1);
	$('.fade_text_2').fadeTo(900,1);
}

});
