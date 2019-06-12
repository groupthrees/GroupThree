window._onReadyList = window._onReadyList || [];
_onReadyList.push( function(){
		$('#JS_common_head_help').hover(
		function(){_show_(this);},function(){_hide_(this);}
	);
		$('#JS_common_head_menu_812').hover(
		function(){
			_show_(this,{source:'JS_all_head_category_menu',target:'JS_head_expand_menu_target'});
		},
		function(){
			_hide_(this);
		}
	);
	$('#JS_head_expand_menu_target').on('mouseenter','div.JS_catItem',function(){
		_show_(this);
	});
	$('#JS_head_expand_menu_target').on('mouseleave','div.JS_catItem',function(){
		_hide_(this);
	});
	$('#JS_MLL_search_header_input').focus(function(){
		$.searchKey( 'JS_MLL_search_header_input', 'JS_search_suggest' );
		$('#JS_MLL_search_header_input').unbind('focus');
	});
} );
$('.quick-area').hover(function(){
	$(this).find('.qrcode-tb').toggle();
});

	//鼠标经过特效
	//顶部下拉菜单\手机二维码\分类树菜单\首页品牌楼层\右侧工具栏\右侧用户面板头像\右侧购物车面板列表\右侧收藏面板分类\右侧收藏面板商品\右侧我看过的面板商品
	$(".menu-item")
	.hover(function(){
		$(this).addClass("hover");
	},function(){
		$(this).removeClass("hover");
	});
