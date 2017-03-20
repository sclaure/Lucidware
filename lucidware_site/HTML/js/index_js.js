//icons fade in
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= ($("#fade_check_1").offset().top-550)) {
	$('.column_pic').fadeTo(400,1);
}

});

//small header fade in
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= ($("#fade_check_1").offset().top-65)) {
	$('.fade_in_2').fadeTo(900,1);
}

});

//small text fade in
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= $("#fade_check_2").offset().top) {
	$('.fade_in_3').fadeTo(900,1);
}

});

//block fade in and slide right
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= $("#fade_check_3").offset().top) {
	$('.details').animate({
		opacity: '.7',
		'margin-right': '0px'
	});
}

});

//second block fade in and slide right
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= $("#fade_check_4").offset().top) {
	$('.details2').animate({
		opacity: '.7',
		'margin-right': '0px'
	});
}

});

//first pic fade in and slide left
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= ($("#fade_check_5").offset().top-250)) {
	$('.side_photo1').animate({
		opacity: '1',
		'margin-left': '0px'
	}, 800);
}

});

//second pic fade in and slide left
$(window).scroll(function(){

var pos = $(window).scrollTop();
if(pos >= ($("#fade_check_6").offset().top-50)) {
	$('.side_photo2').animate({
		opacity: '1',
		'margin-left': '0px'
	}, 800);
}

});
