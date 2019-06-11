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
	/*$("#district").change(function(){
		changeCounty();
	});*/
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

	$("#ajaxForm").validate({
		rules:{
		   consignee:"required nameFormat",
		   district:"required",
		   //street:"required",
		   addressMore:"required",
		   mobile:"required",
		   phone:"mobileRequire mobileFormat phoneFormat",
		   zipcode:"blankButNum"
		},
		focusInvalid: false,
		onkeyup: false,
		focusCleanup:true,
		submitHandler:function(){
			var province = $("#province option:selected").text();
			var city = $("#city option:selected").text();
			var district = $("#district option:selected").text();
			//var street = $("#street option:selected").text();
			//$("#addressName").val(province+'-'+city+'-'+district+'-'+street);
			$("#addressName").val(province+'-'+city+'-'+district);
			var reg = new RegExp("^[A-Za-z0-9\u4e00-\u9fa5\\s,，.。?？!！\\-_【】()\\[Item\\]]+$");
		    if(jQuery.trim($("#address").val()) != '' && !reg.test(jQuery.trim($("#address").val()))){
		    	$('#addressTS').show();
				$('#addressTS').find('span').text('详细地址不能包含敏感字符')
				$('#address').addClass('borderRed');
		    	return false;
		    }
			$("#ajaxForm").ajaxSubmit({
				dataType:'json',
				contentType: "application/x-www-form-urlencoded; charset=utf-8",
				success:function(data){
					if(data.code == '999'){
						 $.showAlert({"content":"不能输入敏感字符!", "type":"alarm" });
						 return false;
					}
					if(data.action_status == 0){
					     $.showAlert({"content":data.action_msgs, "type":"alarm" });
					}else if(data.action_status == -2){
						$.showAlert({"content":"用户地址不存在!", "type":"alarm" });
					}else if(data.action_status == -3){
						$.showAlert({"content":"最多保存20个收货地址!", "type":"alarm" });
					}else if(data.action_status > 0){
						 $.showAlert({"content":"保存成功!", "type":"success",
					     "callback":function(){if(jQuery.trim($("#id").val()) == '')location="/myaccount/address.htm";} })
					}else{
						$.showAlert({"content":"保存失败！", "type":"fail" });
					}
				}
			});
		}
	});
	
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
								content.push('<option selected="selected" value="'+cityData[i].id+'">'+cityData[i].name+'</option>');
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
	
})

function getRandomNum(Min, Max) {
	var Range = Max - Min;
	var Rand = Math.random();
	return (Min + Math.round(Rand * Range));
}

jQuery.validator.addMethod("nameFormat", function (value, element) {  
	var reg = new RegExp("^(\\s*|(([\u4e00-\u9fa5\\s]+)|([a-zA-Z\\s]+)))$");
    if(jQuery.trim($("#people").val()) != '' && !reg.test(jQuery.trim($("#people").val())))
        return false;
    return true;
}, jQuery.validator.format("")); 
jQuery.validator.addMethod("addressFormat", function (value, element) {  
	var reg = new RegExp("^[A-Za-z0-9\u4e00-\u9fa5\\s,，.。?？!！\\-_【】()\\[Item\\]]+$");
    if(jQuery.trim($("#address").val()) != '' && !reg.test(jQuery.trim($("#address").val())))
        return false;
    return true;
}, jQuery.validator.format(""))
jQuery.validator.addMethod("mobileRequire", function (value, element) {  
    if(jQuery.trim($("#iphone").val()) == '' && jQuery.trim($("#phone").val()) == '')
        return false;
    return true;
}, jQuery.validator.format("")); 
jQuery.validator.addMethod("mobileFormat", function (value, element) {  
	var reg = new RegExp(mobileRegex_o_star);
	if($(".ln_addressBoxTitL").html()=='添加新地址'){
		reg = new RegExp(mobileRegex_s);
	}
    if(jQuery.trim($("#iphone").val()) != '' && !reg.test(jQuery.trim($("#iphone").val())))
        return false;
    return true;
}, jQuery.validator.format(""));
jQuery.validator.addMethod("phoneFormat", function (value, element) {  
	var reg = new RegExp("^([0-9]{1,}-?[0-9]{1,})$|^([0-9]{2}\\*{3}[0-9]{1,})$|^([0-9]{1,}-[0-9]{2}\\*{3}[0-9]{1,})$");
	if($(".ln_addressBoxTitL").html()=='添加新地址'){
		reg = new RegExp("^[0-9]{1,}-?[0-9]{1,}$");
	}
	if( jQuery.trim($("#phone").val()) != '' && !reg.test(jQuery.trim($("#phone").val())))
        return false;
    return true;
}, jQuery.validator.format(""));
jQuery.validator.addMethod("blankButNum", function (value, element) { 
    var reg = new RegExp("^[0-9][0-9]{5}$");
    if(jQuery.trim($("#zipcode").val()) != '' &&  !reg.test(jQuery.trim($("#zipcode").val())))
        return false;
    return true;
}, jQuery.validator.format(""));

function deleteAddress(id){
	$.showAlert({"content":"确定要删除吗?", "type":"confirm" ,"cancelShow":true,
		"callback":function(){
			jQuery.ajax({
				 type:'post',
				 url:'/myaccount/deleteAddress.htm',
				 data:{'id':id},
				 dataType:'json',
				 cache:false,
				 async:false,
				 success:function(data){
						if(data.action_status > 0){
						  $.showAlert({"content":"删除成功！", "type":"success",
							  "callback":function(){
								  location="/myaccount/address.htm";
							  }  
						  });
						}else if(data.action_status == -2){	
								$.showAlert({"content":"用户地址不存在!", "type":"alarm" });
							}
				 },
				 error:function(){
					  
				 }
			});
		}
	});
	
	
/*	if(confirm("确定要删除吗?")){
	   jQuery.ajax({
				 type:'post',
				 url:'/myaccount/deleteAddress.htm',
				 data:{'id':id},
				 dataType:'json',
				 cache:false,
				 async:false,
				 success:function(data){
						if(data.action_status == -2){
							alert('用户地址不存在!');	
						}else if(data.action_status > 0){
						  alert("删除成功！");
						  location="/myaccount/address.htm";
						}
				 },
				 error:function(){
					  
				 }
		});
	}*/
}