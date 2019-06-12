$(".chosen-aside").find("li").hover(function() {
        $(this).addClass("current").siblings().removeClass("current")
    })
