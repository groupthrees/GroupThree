
function limitCount() {

	var a = limitCount.doms = limitCount.doms || $("#JS_limit_table div.JS_leaveTime");
	a.each(function() {
		var c = $(this);
		var b = c[0]._timeline = c[0]._timeline || c.data("timeline");
		c.html(limitFormatTime(b - limitCount.unixTime));
	});
	limitCount.unixTime++;
}

function limitFormatTime(e) {
	if (e < 0) {
		e = 0;
	}
	var f = Math.floor(e / 3600 / 24),
	c = Math.floor((e / 3600) % 24),
	a = Math.floor((e % 3600) / 60),
	b = Math.floor((e % 3600) % 60);
	if (c < 10) {
		c = "0" + c;
	}
	if (a < 10) {
		a = "0" + a;
	}
	if (b < 10) {
		b = "0" + b;
	}
	return "剩余" + (f > 0 ? '<span class="digital">' + f + "</span>天": "") + '<span class="digital">' + c + '</span>时<span class="digital">' + a + '</span>分<span class="digital">' + b + "</span>秒";
}
function _COMMON_UNIX_TIME() {
		limitCount.unixTime = 0;
		setInterval(limitCount, 1000);
}
_COMMON_UNIX_TIME();
function getNewDealRecord() {
	
}
function formatTime(i) {
	if (!i) {
		return "刚刚";
	}
	var b = parseInt((new Date()).getTime() / 1000);
	var f = b - i;
	if (f < 0) {
		f = 0;
	}
	var e = f % 60;
	var a = parseInt(f % 3600 / 60);
	var c = parseInt(f % (3600 * 24) / 3600);
	var g = parseInt(f / (3600 * 24));
	if (g) {
		return g + "天前";
	} else {
		if (c) {
			return c + "小时前";
		} else {
			if (a) {
				return a + "分钟前";
			} else {
				if (e) {
					return e + "秒前";
				} else {
					return "刚刚";
				}
			}
		}
	}
}
function dealRecordAnimate() {
	window._JS_ZZ_LOCK_ = false;
	var e = $("#JS_scroll_out_box");
	var b = $("#JS_scroll_out_box .item");
	var a = window.LOAD ? parseInt(b.length / 2) : b.length;
	var c;
	if (a > 3) {
		e.css("margin-top", a * ( - 91) + "px");
		c = -a;
		e.hover(function() {
			window._JS_ZZ_LOCK_ = true;
		},
		function() {
			window._JS_ZZ_LOCK_ = false;
		});
		var d = e.html();
		d += d;
		e.html(d);
		setInterval(f, 4000);
	}
	function f() {
		if (window._JS_ZZ_LOCK_) {
			return;
		}
		c++;
		e.animate({
			"margin-top": c * 91 + "px"
		},
		200, "linear",
		function() {
			if (c > -1) {
				e.css("margin-top", a * ( - 91) + "px");
				c = -a;
			}
		});
	}
}
dealRecordAnimate();
$(function() {
	$.lazyImg.start("both", {
		attributeTag: "data-src2"
	});
	window._currentWidth = document.body.clientWidth;
	window.onresize = function() {
		window._currentWidth = document.body.clientWidth;
		c = 0;
		g();
	};
	var f = $("#JS_side_stage"),
	a = $("#JS_side_stage a"),
	i = $("#JS_side_nav a"),
	b = $("#JS_side_stage a"),
	d = i.length,
	e = 0,
	c = 0;
	i.on("mouseover",
	function() {
		c = $(this).index();
		if (h) {
			clearInterval(h);
		}
		g();
	}).on("mouseout",
	function() {
		h = setInterval(function() {
			g();
		},
		6000);
	});
	var g = function() {
		$(i.get(e)).removeClass("current");
		$(i.get(c)).addClass("current");
		f.stop(true, false).animate({
			"margin-left": (0 - c) * window._currentWidth + "px"
		},
		200);
		e = c;
		var l = $(b.get(e));
		var j = l.attr("data-bg");
		if (j) {
			l.css({
				background: "url(" + j + ") center center no-repeat"
			}).removeAttr("data-bg");
		}
		c = (c >= d - 1) ? 0 : c + 1;
	};
	var h = setInterval(function() {
		g();
	},
	6000);
});
function slideLazy(a) {
	if (a.index > 0) {
		var b = a["_img_" + a.index] || a.stage.find("img").get(a.index);
		if (b && !b._lazYDone) {
			$.lazyImg.prepend([{
				target: b,
				src: b.getAttribute("lazy-src2")
			}]);
			a["_img_" + a.index] = b;
			b._lazYDone = true;
		}
	}
}
$(function() {
	$.tab($("#JS_expr_num_box td.enav"), $("#JS_expr_num_box td.ebody"), {
		lazy: false
	});
	$.tab($("#JS_side_tab_nav a"), $("#JS_side_tab_body .tBody"), {
		lazy: false
	});
	$("#JS_group_buy_body").on("mouseover",
	function() {
		this.className = "body current";
	}).on("mouseout",
	function() {
		this.className = "body";
	});
	$.slide({
		prevBtn: $("#JS_group_nav_prev"),
		nextBtn: $("#JS_group_nav_next")
	},
	$("#JS_groupBuy_stage"), {
		step: 210
	});
	$.slide({
		prevBtn: $("#JS_limit_left"),
		nextBtn: $("#JS_limit_right")
	},
	$("#JS_limit_table"), {
		step: window.LOAD ? 960 : 750,
		onSlide: function(b) {
			if (b.index > 0 && !b._lazYDone) {
				var e = b.stage.find("div.img img");
				var d = [];
				for (var c = 3; c < 6; c++) {
					if (e[c]) {
						d.push({
							target: e[c],
							src: e[c].getAttribute("lazy-src2")
						});
					}
				}
				if (d.length) {
					$.lazyImg.prepend(d);
				}
				b._lazYDone = true;
			}
		}
	});
	$("#JS_limit_table").on("mouseenter", "td",
	function() {
		this.className = "current";
	});
	$("#JS_limit_table").on("mouseleave ", "td",
	function() {
		this.className = "";
	});
	$("#JS_check_order").on("click",
	function() {
		orderQuery();
	});
	for (var a = 1; a <= 4; a++) {
		$.slide($("#JS_floor_focus_nav_" + a + " a"), $("#JS_floor_focus_stage_" + a), {
			step: 230,
			eventType: "mouseenter",
			autoRun: 5000,
			onSlide: slideLazy
		});
	}
});

function orderQuery()
{
  var order_sn = $('#JS_ordersn').val();

  var reg = /^[\.0-9]+/;
  if (order_sn.length < 10 || ! reg.test(order_sn))
  {
    $.alert('无效订单号!');
    return;
  }
  $.ajax({
					type:"GET",
					url:'/user.php?act=order_query&order_sn=s' + order_sn,
					cache:false,
					dataType:'json',     //接受数据格式
					data:'',
					success:orderQueryResponse
				});
}

function orderQueryResponse(result)
{
  if (result.message.length > 0)
  {
    $.alert(result.message);
  }
  if (result.error == 0)
  {
	$.alert(result.content);
  }
}

$(window).on("load",
function() {
	$.slide($("#JS_zx_slide_nav a"), $("#JS_zx_slide_body"), {
		step: 510,
		eventType: "mouseenter",
		autoRun: 3000,
		onSlide: slideLazy
	});
	$.slide($("#JS_focus_xspace_nav a"), $("#JS_focus_xspace_body"), {
		step: 567,
		eventType: "mouseenter",
		autoRun: 3500,
		onSlide: function(b) {
			var a = b.index;
			if (a > 0 && !b["_lazyDone_" + a]) {
				var e = b.stage.find("div.img img");
				var d = [];
				for (var c = a * 3; c < (a + 1) * 3; c++) {
					if (e[c]) {
						d.push({
							target: e[c],
							src: e[c].getAttribute("lazy-src2")
						});
					}
				}
				if (d.length) {
					$.lazyImg.prepend(d);
				}
				b["_lazyDone_" + a] = true;
			}
		}
	});
	$.tab($("#JS_tab_article_nav a"), $("#JS_tab_article_body div.tabBody"));
	getNewDealRecord();
	$("#JS_hotBrand_table").on("mouseenter", "td",
	function() {
		$(this).addClass("current");
	});
	$("#JS_hotBrand_table").on("mouseleave ", "td",
	function() {
		$(this).removeClass("current");
	});
});