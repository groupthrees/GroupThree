// 删除收藏商品的方法
function deleteCollect(id,leibie,pageNum){
	 var currRecordSize = $("#currRecordSize").val();
	
	 $.showAlert({"content":"确定要取消收藏吗？", "type":"confirm","cancelShow":true, 
	    	"callback":function(){
	    		jQuery.ajax({
					 type:'post',
					 url:'/trademanage/delete_collect.htm',
					 data:{'ids':id,'leibie':leibie},
					 dataType:'json',
					 cache:false,
					 async:true,
					 success:function(data){
							if(data.action_status == -3){
								$.showAlert({"content":"用户收藏不存在!", "type":"alarm" });
							}if(data.action_status == -2){
								$.showAlert({"content":"参数错误!", "type":"alarm" });
							}else if(data.action_status == -1){
							    $.showAlert({"content":"取消收藏失败！", "type":"fail" });
							}else if(data.action_status == 1){
							    $.showAlert({"content":"取消收藏成功!", "type":"success",
									"callback":function(){//如果当前页无记录，跳转到前一页
									    if(pageNum > 1 && currRecordSize-1 == 0){
									    	pageNum = pageNum - 1;
									    }
									    location = '/trademanage/my_collect.htm?pageNum='+pageNum+'&rome='+leibie; 							
									} })

							}
					 },
					 error:function(){
						  
					 }
   			});
	    }
	 })
 } 

//批量取消收藏
function deleteCollectByIds(leibie,pageNum){
	 var text=""; 
	 var num=0;
	 $("input[name=items]").each(function() {  
         if ($(this).attr("checked")) {  
			 if(text!=""){
				 text += ","; 
			 }
			 text+=$(this).val(); 
			 num++;
         }  
     });  
    if(text=="")
	   {
	    $.showAlert({"content":"请选择您要取消收藏的商品！", "type":"alarm" });
	    return;
	   }
    var currRecordSize = $("#currRecordSize").val();
    $.showAlert({"content":"确定要取消收藏吗？", "type":"confirm","cancelShow":true, 
    	"callback":function(){
    		jQuery.ajax({
					 type:'post',
					 url:'/trademanage/delete_collect.htm',
					 data:{'ids':text,'leibie':leibie},
					 dataType:'json',
					 cache:false,
					 async:true,
					 success:function(data){
							if(data.action_status == -3){
								$.showAlert({"content":"用户收藏不存在!", "type":"alarm" });
							}if(data.action_status == -2){
								$.showAlert({"content":"参数错误!", "type":"alarm" });
							}else if(data.action_status == -1){
							    $.showAlert({"content":"取消收藏失败！", "type":"fail" });
							}else if(data.action_status == 1){
							    $.showAlert({"content":"取消收藏成功！", "type":"success",
								    "callback":function(){
								    	 //如果当前页无记录，跳转到前一页
									    if(pageNum > 1 && currRecordSize-num == 0){
									    	pageNum = pageNum - 1;
									    }
										location = '/trademanage/my_collect.htm?pageNum='+pageNum+'&rome='+leibie;
								    }
							    });
							}
					 },
					 error:function(){
						  
					 }
			});
    	}
    })
 }
//批量加入购物车
function addtoCart(leibie,pageNum){
	var proIds="";  
	var nums="";
	var haveDzPro = false;
	$("input[name=items]").each(function() {  
        if ($(this).attr("checked")) {  
			if($(this).attr("data") != 5){
			    if($(this).attr("is-sale") != undefined && $(this).attr("is-sale").trim() != "n") {
                    if(proIds!=""){
                        proIds += ",";
                        nums += ",";
                    }
                    collectId = $(this).val();
                    proIds += $("#"+collectId).val();
                    nums += "1";
                }
			}else{
				haveDzPro = true;
			}        	
        }  
   });  
   if(proIds==""){
	   if(haveDzPro){
		   showDzAlert({"content":"因业务关系，您选取的私人定制商品将不被加入购物车。", "type":"alarm",
			   "callback":function(){
				   showDzAlert({"content":"请选择您要加入购物车的商品！", "type":"alarm"});
			   }   
		   });
	   }else{
		   showDzAlert({"content":"请选择您要加入购物车的商品！", "type":"alarm"});
	   }	   
	   return;
   }else{
   		if (haveDzPro) {
		   showDzAlert({"content":"因业务关系，您选取的私人定制商品将不被加入购物车。", "type":"alarm","cancelShow":true,
			   "callback":function(){
				   var shop_cart_request_url = "/cart/addToCart.htm";
				   jQuery.post(shop_cart_request_url, {
					   "productIds" : proIds
				   }, function(data) {
					   if (data.action_status == 1) {
						   if (data.cart_key) {
							   setCookie("cart", data.cart_key, 7)
						   }
						   if (data.goods_count) {
							   setCookie("cart_goods_count", data.goods_count, 7)
						   }

						   var cartNum = data.goods_count;
						   $("#alt_num").html(cartNum);
						   if (cartNum > 999) {
							   $(".jx_car_num").text("999+")
						   } else {
							   $(".jx_car_num").text(cartNum)
						   }
						   setTimeout(function() {
								   timer
							   },
							   500);
						   var sc = $(document).scrollTop() + ($(window).height() / 2) - 110;
						   $(".alt_succ").css({
							   "top": sc
						   });
						   $(".alt_succ").show();
						   timer = setTimeout(function() {
								   if ($.browser.version == "6.0" || $.browser.version == "7.0") {
									   $(".alt_succ").hide()
								   } else {
									   $(".alt_succ").fadeOut(600)
								   }
								   clearTimeout(timer)
							   },
							   5000)
						   if(data.action_status=="1"){
							   showDzAlert({"content":"添加购物车成功!", "type":"success"});
						   }

					   } else {
						   alert(data.action_msgs);
					   }
				   }, "JSON")
			   }
		   });
   		}else {
            var shop_cart_request_url = "/cart/addToCart.htm";
            jQuery.post(shop_cart_request_url, {
                "productIds" : proIds
            }, function(data) {
                if (data.action_status == 1) {
                    if (data.cart_key) {
                        setCookie("cart", data.cart_key, 7)
                    }
                    if (data.goods_count) {
                        setCookie("cart_goods_count", data.goods_count, 7)
                    }

                    var cartNum = data.goods_count;
                    $("#alt_num").html(cartNum);
                    if (cartNum > 999) {
                        $(".jx_car_num").text("999+")
                    } else {
                        $(".jx_car_num").text(cartNum)
                    }
                    setTimeout(function() {
                            timer
                        },
                        500);
                    var sc = $(document).scrollTop() + ($(window).height() / 2) - 110;
                    $(".alt_succ").css({
                        "top": sc
                    });
                    $(".alt_succ").show();
                    timer = setTimeout(function() {
                            if ($.browser.version == "6.0" || $.browser.version == "7.0") {
                                $(".alt_succ").hide()
                            } else {
                                $(".alt_succ").fadeOut(600)
                            }
                            clearTimeout(timer)
                        },
                        5000)
                    if(data.action_status=="1"){
                        showDzAlert({"content":"添加购物车成功!", "type":"success"});
                    }

                } else {
                    alert(data.action_msgs);
                }
            }, "JSON")
		}
   }
}


var timer = null;

var toCartCallBack = function(data) {
    //var cartNum = data.goods_count;
    //$("#alt_num").html(cartNum);
    //if (cartNum > 999) {
    //    $(".jx_car_num").text("999+")
    //} else {
    //    $(".jx_car_num").text(cartNum)
    //}
    setTimeout(function() {
        timer
    },
    500);
    var sc = $(document).scrollTop() + ($(window).height() / 2) - 110;
    $(".alt_succ").css({
        "top": sc
    });
    $(".alt_succ").show();
    timer = setTimeout(function() {
        if ($.browser.version == "6.0" || $.browser.version == "7.0") {
            $(".alt_succ").hide()
        } else {
            $(".alt_succ").fadeOut(600)
        }
        clearTimeout(timer)
    },
    5000)
    if(data.status=="1"){
    	$.showAlert({"content":"添加购物车成功!", "type":"success"});
    }
};


function addcart(goodsId){ 
    var shop_cart_request_url = "/cart/addToCart.htm";
    jQuery.post(shop_cart_request_url, {
        "productId" : goodsId,
    }, function(data) {
        if (data.action_status == 1) {
            if (data.cart_key) {
                setCookie("cart", data.cart_key, 7)
            }
            if (data.goods_count) {
                setCookie("cart_goods_count", data.goods_count, 7)
            }
            showDzAlert({"content":"添加购物车成功!", "type":"success"});
        } else {
            alert(data.action_msgs);
        }
    }, "JSON")
}



//收藏商品
function addCollect(proId) {
	jQuery.ajax({
		type : 'post',
		url : domain_detail+'/pro/selectLoginSession.htm?t=' + new Date().getTime().toString(),
		data : {},
		dataType : 'json',
		async : true,
		success : function(data) {
			if (data.code == 0) {
				$.getJSON(domain_detail+"/pro/saveCollect.htm", {
					'proId' : proId
				}, function(data) {
					if (data) {
						if (data.code == -1) {
							alert('收藏失败!');
							return false;
						} else if (data.code == 0) {
							alert('收藏成功!');
							return false;
						} else if (data.code == 1) {
							window.location.href = domain_passprot
									+ '/login.htm';
							return false;
						} else if (data.code == 2) {
							alert("您已经收藏过此商品了！");
							return false;
						}
					}
				});
			} else {
				// alert("您还没有登录，请先登录！");
				window.location.href = domain_passprot
						+ '/login.htm';
				return false;
			}
		}
	});
}

function showDzAlert(option){
	var popr = '<div class="pop-modal"></div><div class="pop-wrap pop-wrap1"><div class="pop-layer"><div class="pop-title"><p class="alertTitle">提示</p><i class="popIcon alertClose"></i></div><div class="pop-main"><i class="popIcon popType success"></i><i class="popIcon popType fail"></i><i class="popIcon popType alarm"></i><i class="popIcon popType confirm"></i><p><span class="alertContent">操作成功</span><em></em></p></div><div class="pop-bottom"><span class="confirm alertSure"><b>确定</b></span><span class="cancel alertCancel"><b>取消</b></span></div></div></div>';
	$(".pop-modal").remove();
	$(".pop-wrap").remove();
	$("body").append(popr);
	
	var defaults={
		"target":$(".pop-wrap1"),   //弹窗目标对象		
		"title":"提示",            //弹窗提示title
		"content":"操作成功",        //弹窗提示内容
		"type":"success",                //弹窗类型  成功(success)、失败(fail)、警告(alarm)、对话（confirm）       
		"cancelShow":false,          //是否显示取消按钮  默认不显示
		"callback":null				//添加回调函数
		}
	var option = $.extend(defaults,option);
	$(".pop-modal").show();
	option.target.show();
	option.target.find(".popType").hide();
	option.target.find("."+option.type).show();
	option.target.find(".alertTitle").text(option.title);
	option.target.find(".alertContent").text(option.content);
	var hideAlert = function(){
		$(".pop-modal").hide();
		option.target.hide();				
	}

	if(!option.cancelShow)
	{
		option.target.find(".alertCancel").hide();
	}
	option.target.find(".alertSure").bind("click",function(){
		hideAlert();	
		if(option.callback&&typeof(option.callback)=="function")
		{									
				option.callback();
				if(option.type=="confirm")
					{
						option.callback = null;
					}
		}
					
	});
	
	      
	$(".alertClose,.alertCancel").bind("click",function(){
		option.callback = null;
		hideAlert();	
		
	});	
	
	$("body").bind("keyup",function(e){
		if(e.which==13){
			option.target.find(".alertSure").trigger("click");									
		}
		if(e.which==27){
			hideAlert();								
		}
		$("body").unbind("keyup");	
	});	

}
