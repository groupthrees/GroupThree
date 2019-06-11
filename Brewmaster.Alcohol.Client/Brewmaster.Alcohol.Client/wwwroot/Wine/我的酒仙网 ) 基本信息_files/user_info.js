$(function(){
	$("#province").change(function(){
		changeProvince();
		changeCity();
		changeCounty();
	});
	$("#city").change(function(){
		changeCity();
		changeCounty();
	});
	$("#district").change(function(){
		changeCounty();
	});
	$("#street").change(function(){
		var street = $("#street").val();
		if(street != null || street != ''){
			$("#streetDiv").find(".accNotic").hide();	
		}
	});
	
//获取省市区数据
function getNextRegionList(pId){
      var jsonData = null;
      jQuery.ajax({
		 type:'post',
		 url:'/myaccount/getNextRegionList.htm',
		 data:{'pId':pId},
		 dataType:'json',
		 cache:false,
		 async:false,
		 success:function(data){
		     jsonData = data;            
		 },
		 error:function(){
			 $.showAlert({"content":"操作失败,请稍后重试!", "type":"fail" });
		 }
	 });
	 return jsonData;
}
//切换省
function changeProvince(){
   var pId = jQuery.trim($("#province").val());
   if(pId != ''){
        var jsonData  =  getNextRegionList(pId);
		if(jsonData != null && jsonData.list != null && jsonData.list.length > 0){
            var content = [];
			content.push('<option value="">请选择</option>');
			for(var i = 0;i<jsonData.list.length;i++){
			    content.push('<option value="'+jsonData.list[i].ID+'">'+jsonData.list[i].name+'</option>');
			}	
			$("#city").empty().append(content.join(''));
		}
   }else{
	   $("#city").empty().append('<option value="">请选择</option>'); 
   }
}
//切换市
function changeCity(){
       var pId = jQuery.trim($("#city").val());
	   if(pId != ''){
	        var jsonData  =  getNextRegionList(pId);
			if(jsonData != null && jsonData.list != null && jsonData.list.length > 0){
		            var content = [];
					content.push('<option value="">请选择</option>');
					for(var i = 0;i<jsonData.list.length;i++){
					    content.push('<option value="'+jsonData.list[i].ID+'">'+jsonData.list[i].name+'</option>');
					}	 
					$("#district").empty().append(content.join(''));
			}
	   }else{
		   $("#district").empty().append('<option value="">请选择</option>'); 
	   }
}
//切换县
function changeCounty(){
       var pId = jQuery.trim($("#district").val());
	   if(pId != ''){
	        var jsonData  =  getNextRegionList(pId);
			if(jsonData != null && jsonData.list != null && jsonData.list.length > 0){
		            var content = [];
					content.push('<option value="">请选择</option>');
					for(var i = 0;i<jsonData.list.length;i++){
					    content.push('<option value="'+jsonData.list[i].ID+'">'+jsonData.list[i].name+'</option>');
					}	 
					$("#street").empty().append(content.join(''));
			}
	   }else{
		   $("#street").empty().append('<option value="">请选择</option>'); 
	   }
}

//修改时初始化下拉框
var addressId = $("#addressId").val();
if(addressId != null && addressId != ''){
	jQuery.ajax({
		type : 'post',
		url : '/myaccount/selectAddress.htm?t=' + getRandomNum(1, 100),
		data : {
			'id' : addressId
		},
		dataType : 'json',
		cache : false,
		async : false,
		success : function(data) {
			if (data && data.code == 0) {
				var street = data.address.rgn_RegionID;
				var streetData = data.streetList;
				var countryData = data.countryList;
				var cityData = data.cityList;
				var provinceData = data.provinceList;
				var addressIds = data.addressIds.split("-");
				var provice = addressIds[0];
				var city = addressIds[1];
				var country = addressIds[2];
				var street = addressIds[3];
				//初始化街道
				if(streetData != null && streetData.length > 0){
					var content = [];
					content.push('<option value="">请选择</option>');
					for(var i = 0;i<streetData.length;i++){
						if(street==streetData[i].id){
							 content.push('<option selected="selected" value="'+streetData[i].id+'">'+streetData[i].name+'</option>');
						}else{
							 content.push('<option value="'+streetData[i].id+'">'+streetData[i].name+'</option>');
						}
					}	 
					$("#street").empty().append(content.join(''));
				}
				//初始化县
				if(countryData != null && countryData.length > 0){
		            var content = [];
					content.push('<option value="">请选择</option>');
					for(var i = 0;i<countryData.length;i++){
						if(country==countryData[i].id){
							content.push('<option selected="selected" value="'+countryData[i].id+'">'+countryData[i].name+'</option>');
						}else{
							content.push('<option value="'+countryData[i].id+'">'+countryData[i].name+'</option>');
						}
					}	 
					$("#district").empty().append(content.join(''));
				}
				//初始化市
				if(cityData != null && cityData.length > 0){
		            var content = [];
					content.push('<option value="">请选择</option>');
					for(var i = 0;i<cityData.length;i++){
						if(city==cityData[i].id){
							content.push('<option selected="selected" value="'+cityData[i].ID+'">'+cityData[i].name+'</option>');
						}else{
							content.push('<option value="'+cityData[i].id+'">'+cityData[i].name+'</option>');
						}
					}	 
					$("#city").empty().append(content.join(''));
				}
				//初始化省
				if(provinceData != null && provinceData.length > 0){
		            var content = [];
					content.push('<option value="">请选择</option>');
					for(var i = 0;i<provinceData.length;i++){
						if(provice==provinceData[i].id){
							content.push('<option selected="selected" value="'+provinceData[i].id+'">'+provinceData[i].name+'</option>');
						}else{
							content.push('<option value="'+provinceData[i].id+'">'+provinceData[i].name+'</option>');
						}
					}	 
					$("#province").empty().append(content.join(''));
				}
			}
		},
		error : function() {
			alert('错误');
		}
		});
	}

	//校验提交个人信息
	$("#ajaxForm").validate({
		rules:{
		   anotherName:"required",	
		   realName:"nameFormat",
		   birthday:"required",
		   sex:"required"
		},
		focusInvalid: false,
		onkeyup: false,
		focusCleanup:true,
		submitHandler:function(){
			
			var cateIds="";
			$('.zpTag .on').each(function() { 
				if(cateIds != ""){
	        		 cateIds += ",";
	        	 }
				 cateIds += $(this).attr('cid');
		    }); 
			$("#cateIds").val(cateIds);
		    
		    var likeBrand = $("#likeBrand").val(); 
			var birthday = $("#setBirthday").val();
			$("#birthday").val(birthday);
			var reg = /^(\d{4})(-)(\d{2})(-)(\d{2})$/;
		    if(birthday != '' && !reg.test(birthday)){
		    	return false;
		    }
		    var reg2 = new RegExp("^[A-Za-z0-9\u4e00-\u9fa5\\s,，.。?？!！\\-_【】()\\[Item\\]]+$");
		    if(jQuery.trim($("#addressMore").val()) != '' && !reg2.test(jQuery.trim($("#addressMore").val()))){
		    	$('#addressMoreTS').show();
				$('#addressMoreTS').find('span').text('详细地址不能包含敏感字符')
				$('#addressMore').addClass('borderRed');
		    	return false;
		    }
		    var reg3 = new RegExp("^([a-zA-Z0-9_-]|[\\u4E00-\\u9FFF])+$", "g");
		    if(!reg3.test($("#anotherName").val())){
				return false;
			}
		    //地区验证
		    var province = $("#province").val();
			var city = $("#city").val();
			var district = $("#district").val();
			var street = $("#street").val();
			if((street != '' && district != '' && city != '' && province != '')
					|| (street == '' && district == '' && city == '' && province == '')){
				$("#streetDiv").find(".accNotic").hide();	
			}else{
				$("#streetDiv").find("span").text("地址选择不完整");
				$("#streetDiv").find(".accNotic").show();
				return false;
			}

			$("#ajaxForm").ajaxSubmit({
				dataType:'json',
				contentType: "application/x-www-form-urlencoded; charset=utf-8",
				success:function(data){
					if(data.code == '999'){
						 $.showAlert({"content":"不能输入敏感字符！", "type":"alarm" });
					}
				    if(data.action_status == 30){
				    	$.showAlert({"content":data.action_msgs, "type":"alarm" });
					}else if(data.error_message != null && data.error_message != ''){
						$.showAlert({"content":data.error_message, "type":"alarm" });
					}else if(data.error_anotherName != null && data.error_anotherName != ''){
						$.showAlert({"content":data.error_anotherName, "type":"alarm" });
					}else if(data.action_status == 1){
						$.showAlert({"content":"保存成功!", "type":"success" });
					}else if(data.action_status == -1){
					    $.showAlert({"content":"保存失败!", "type":"fail" });
					}
				},
				error:function(){
				    $.showAlert({"content":"保存失败，或请检查是否已经登录!", "type":"alarm" });
				}
			});
		}
	});
	
/*	$('#saveInfo').bind('click',function(){ 
		var province = $("#province").val();
		var city = $("#city").val();
		var district = $("#district").val();
		var street = $("#street").val();
		if(street == null || street == '' || district == null || district == '' || city == null || city == '' || province == null || province == ''){
			$("#streetDiv").find("span").text("请选择地区");
			$("#streetDiv").find(".accNotic").show();	
		}else{
			$("#streetDiv").find(".accNotic").hide();	
		}
	});*/
	
})

function getRandomNum(Min, Max) {
	var Range = Max - Min;
	var Rand = Math.random();
	return (Min + Math.round(Rand * Range));
}

var uploadPicDomain = 'http://jximage.jxwmanage.com';
var picDomain = 'http://img12.jiuxian.com';

jQuery.validator.addMethod("nameFormat", function (value, element) {  
	var reg = new RegExp("^([\u4e00-\u9fa5]+)|([a-zA-Z]+)$");
    if(jQuery.trim($("#realName").val()) != '' && !reg.test(jQuery.trim($("#realName").val())))
        return false;
    return true;
}, jQuery.validator.format("")); 
jQuery.validator.addMethod("specialCharCheck", function (value, element) {  
	var reg = new RegExp("^[^<>\'\"]+$");
    if(value != '' && !reg.test(value))
        return false;
    return true;
}, jQuery.validator.format(""));

function GetRandomNum(Min,Max){   
	var Range = Max - Min;   
	var Rand = Math.random();   
	return(Min + Math.round(Rand * Range));   
}

function saveExt(){
	var maritalStatus = $("#maritalStatus").val();
	var eduLevel = $("#eduLevel").val();
	var industry = $("#industry").val();
	var profession = $("#profession").val();
	var income = $("#income").val();
	
	if(maritalStatus == null || maritalStatus == ''){
		return false;
	}
	if(eduLevel == null || eduLevel == ''){
		return false;
	}
	if(industry == null || industry == ''){
		return false;
	}
	if(profession == null || profession == ''){
		return false;
	}
	if(income == null || income == ''){
		return false;
	}
	/*if(likeBrand == null || likeBrand == ''){
		return false;
	}*/

	
    //return false;
	jQuery.ajax({
		 type:'post',
		 url:'/myaccount/saveUserExtInfo.htm',
		 data:{'maritalStatus':maritalStatus,'eduLevel':eduLevel,'industry':industry,'profession':profession,'income':income},
		 dataType:'json',
		 cache:false,
		 success:function(data){
			 if(data.code == '999'){
				 $.showAlert({"content":"不能输入敏感字符！", "type":"alarm" });
			 }
		     if(data.action_status == 30){
			     $.showAlert({"content":data.action_msgs, "type":"alarm" });
			 }else if(data.error_message != null && data.error_message != ''){
				 $.showAlert({"content":data.error_message, "type":"alarm" });
			 }else if(data.error_anotherName!=null && data.error_anotherName!=''){
				 $.showAlert({"content":data.error_anotherName, "type":"alarm" });
			 }else if(data.action_status == -1){
				 $.showAlert({"content":"保存失败!", "type":"fail" });
			 }else if(data.action_status == 1){
				 $.showAlert({"content":"保存成功!", "type":"success"});
			 }
		 },
		 error:function(){
			 $.showAlert({"content":"保存失败，或请检查是否已经登录", "type":"alarm" });
		 }
	});	
}

//保存推荐头像
function saveRecHeadPhoto(){
	var imgPath = $("#recHeadPhoto").attr("src");
	if(imgPath == null || imgPath == ''){
	    $.showAlert({"content":"请选择图片文件！", "type":"alarm" });
	    return null;
	}
	if(updataUserHead(imgPath)){
	     $.showAlert({"content":"保存头像成功!", "type":"success"});
	     $("#headImagePath").attr("src",imgPath);
	     //$("#xuwanting").attr("src",imgPath);
	     //$("#crop_preview").attr("src",imgPath);
	     //$(".bigHeadPhoto").attr("src",imgPath)
	     $("#myImg").attr("value",imgPath);
	     //$(".imgBox").find("img").eq(0).remove();
 		// $(".imgBox").find(".jcrop-holder").remove();
    }
}

function updataUserHead(imgPath){
    var  tf = false;
    jQuery.ajax({
	      type:'post',
	      url:'/myaccount/updateHeadImg.htm',
	      data:{"imgPath":imgPath},
	      dataType:'json',
	      cache:false,
	      async:false,
	      success:function(data){
				 if(data.returnCode > 0){
                     tf  = true;
				 }
	       },
	       error:function(e){

	       }
	  });
	  return tf;
}

/*剪裁照片*/

function uploadImage(){
	  var jcrop_api;
			var i, ac;
			initJcrop();
			function initJcrop(){
				jcrop_api = $.Jcrop("#xuwanting"),{ 
				setSelect:[50,50,100,100]
				};
				/*jcrop_api.setOptions({
					minSize:[50, 50],
					maxSize:[100, 100]
				});*/
				jcrop_api.focus();
				jcrop_api.setSelect(getRandom());
				
			};
			// 使用API找到需要修剪的尺寸，然后产生一个随机的选区
			// 此函数主要用于"随机选区"和"随机动画"这两个按钮，主要目的是演示示范
			function getRandom(){
				var dim = jcrop_api.getBounds();
				return [
					Math.round(Math.random() * dim[0]),
					Math.round(Math.random() * dim[1]),
					Math.round(Math.random() * dim[0]),
					Math.round(Math.random() * dim[1])
				];
			};	
			$("#xuwanting").Jcrop({
				aspectRatio:1,
				onChange:showCoords,
				onSelect:showCoords
			});	
			//简单的事件处理程序，响应自onChange,onSelect事件，按照上面的Jcrop调用
			function showCoords(obj){
				$("#x").val(obj.x);
				$("#y").val(obj.y);
				$("#w").val(obj.w);
				$("#h").val(obj.h);
				if(parseInt(obj.w) > 0){
					//计算预览区域图片缩放的比例，通过计算显示区域的宽度(与高度)与剪裁的宽度(与高度)之比得到
					var rx = $("#preview_box").width() / obj.w; 
					var ry = $("#preview_box").height() / obj.h;
					//通过比例值控制图片的样式与显示
					$("#crop_preview").css({
						width:Math.round(rx * $("#xuwanting").width()) + "px",	//预览图片宽度为计算比例值与原图片宽度的乘积
						height:Math.round(rx * $("#xuwanting").height()) + "px",	//预览图片高度为计算比例值与原图片高度的乘积
						marginLeft:"-" + Math.round(rx * obj.x) + "px",
						marginTop:"-" + Math.round(ry * obj.y) + "px"
					});
				}
			}
			
	  }

/*function showCoords(obj){
			$("#x").val(obj.x);
			$("#y").val(obj.y);
			$("#w").val(obj.w);
			$("#h").val(obj.h);
			if(parseInt(obj.w) > 0){
				//计算预览区域图片缩放的比例，通过计算显示区域的宽度(与高度)与剪裁的宽度(与高度)之比得到
				var rx = $("#preview_box").width() / obj.w; 
				var ry = $("#preview_box").height() / obj.h;
				//通过比例值控制图片的样式与显示
				$("#crop_preview").css({
					width:Math.round(rx * $("#xuwanting").width()) + "px",	//预览图片宽度为计算比例值与原图片宽度的乘积
					height:Math.round(rx * $("#xuwanting").height()) + "px",	//预览图片高度为计算比例值与原图片高度的乘积
					marginLeft:"-" + Math.round(rx * obj.x) + "px",
					marginTop:"-" + Math.round(ry * obj.y) + "px"
				});
			}
		}*/



var imageUploadUrl = uploadPicDomain+"/upload.htm?category=5";
$(function() {
    filecount = 0;
    $("#saveUploadHead").uploadify({
        "swf": "/resources/js/uploadify/uploadify.swf",
        "button_image_url": "/resources/js/uploadify/spacer.gif",
        "uploader": "/myaccount/uploadAvatar.htm?target="+encodeURIComponent(imageUploadUrl),
        "cancelImage": "/resources/js/uploadify/uploadify-cancel.jpg",
        "queueSizeLimit": 1,
        'fileSizeLimit':'200K',
        "buttonText": "",
        //"fileTypeExts": "*.jpg;*.gif;*.png;*.swf",
        "fileTypeExts": "*.jpg;*.png",
        //"fileTypeDesc": "Image Files (.JPG, .GIF, .PNG, .SWF)",
        "fileTypeDesc": "Image Files (.JPG, .PNG)",
        "multi": false,
        "width": "58",
        "height": "28",
        "auto": true,
        "debug": false,
        "queueID": "fileQueue",
        "onSelect": function(file) {
            filecount++
        },
        "onCancel": function(file) {
            filecount--
        },
        "onFallback": function() {
            alert("您未安装FLASH控件，无法上传图片！请安装FLASH控件后再试。")
        },
        "onUploadSuccess": function(event, response, status) {
        	if(response=='' || response==undefined){
					alert("上传的图片不符合规格！");
					return false;
			}
            var json = eval("(" + response + ")");
            status = json.status;
            if (status == 1) {
            	var lur="http://img12.jiuxian.com" + json.files[0].path;
            	var pt = hex_md5(hex_md5(lur));	      
	        	setCookie("yhzxSignCode",pt,1);
        		var img="<img id='xuwanting' class='bigHeadPhoto' src='"+lur+"' width='300' height='300' >";
        		$(".imgBox").find("img").eq(0).remove();
        		$(".imgBox").append(img);
        		$(".imgBox").find(".jcrop-holder").remove();
        		$(".imgBox").find("img").attr("src", "http://img12.jiuxian.com" + json.files[0].path);
        		$("#crop_preview").attr("src", "http://img12.jiuxian.com" + json.files[0].path);
        		$("#preview_box").append("<img id='crop_preview' src='"+lur+"'  width='100' height='100' />")
        		uploadImage();
            }
        }
    });
    
    //上传剪切后头像
    $("#saveUploadHeadPhoto").click(function(){
		  var x = jQuery.trim($("#x").val());
		  var y = jQuery.trim($("#y").val());
		  var h = jQuery.trim($("#h").val());
		  var w = jQuery.trim($("#w").val());
		  var z = jQuery.trim($("#z").val());
		  var userId = jQuery.trim($("#userId").val());
		  var imgPath = jQuery.trim($(".bigHeadPhoto").attr("src"));
		  
		  var myImg = $("#myImg").val();
		  if(imgPath == '' || imgPath == 'http://misc.jiuxian.com/img/usercenter/bbiigg.jpg'){
			  $.showAlert({"content":"请选择图片文件！", "type":"alarm" });
			  return false;
		  }
		  
		  var pt = hex_md5(hex_md5(imgPath));	      
      	  var pt2 = getCookie("yhzxSignCode");
      	  
      	  if(pt==pt2){      		  
      	  }else{
      		  alert("上传的图片不符合规格！");
      		  return false;
      	  }
		  if(imgPath == myImg){
			  $.showAlert({"content":"请选择不同的图片!", "type":"alarm" }); 
			  return false;
		  }
		  if(x == '' || y == '' || h == '' || w == ''){
			  $.showAlert({"content":"请裁剪图片!", "type":"alarm" });
			  return false;
		  }
		  if(imgPath.indexOf("?") != -1)imgPath = imgPath.substring(0,imgPath.indexOf("?"));
		  var url = uploadPicDomain+'/headImgCut.htm';
		  var time = new Date();
		  jQuery.ajax({
		      type:'post',
		      url:'/httpProxyAccess.htm?target='+encodeURIComponent(url)+"&t="+time.getTime(),
		      data:{"x":x,'y':y,'h':h,'w':w,'z':z,'userId':userId,'imgPath':imgPath},
		      dataType:'json',
		      cache:false,
		      async:false,
		      success:function(data){
					 if(data.returnCode==0){						   
						   if(updataUserHead(data.imgPath)){
							     $.showAlert({"content":"保存头像成功!", "type":"success"});
							     $("#headImagePath").attr("src","http://img12.jiuxian.com" + data.imgPath+"?t="+time.getTime());
						   }
					 }
		       },
		       error:function(e){
		       }
		  });
		
	});
    
});