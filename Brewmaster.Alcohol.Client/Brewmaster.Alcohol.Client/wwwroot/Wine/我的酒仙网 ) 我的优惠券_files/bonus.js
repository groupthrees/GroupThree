
   function changeCheckCode(){
       $("#checkCodeId").attr("src",$("#checkCodeId").attr("src")+"?");
   }
   function activeBonus(){
	     var bonussn = jQuery.trim($("#bonus_sn").val());
	     var aa = /[//<>@*]+/;
         if(aa.test(bonussn)){
        	 $.showAlert({"content":"包含非法字符,请重新输入！", "type":"alarm" });return;
     	 }	 
	     jQuery.ajax({
             type:'post',
             url:'/purse/activeBonus.htm',
             data:{'bonusNum':jQuery.trim($("#bonus_sn").val()),'checkCode':jQuery.trim($("#cap").val())},
             dataType:'json',
             cache:false,
             success:function(data){
            	 if(data.code == '999'){
            		 $.showAlert({"content":"不能输入敏感字符!", "type":"alarm" });
					 return false;
            	 }
                 if(data.action_status==-2){
                	 $.showAlert({"content":"验证码已过期!", "type":"alarm" });
				 }else if(data.action_status==99){
					 $.showAlert({"content":"请输入序列号!", "type":"alarm" });
				 }else if(data.action_status==-3){
					 $.showAlert({"content":"验证码输入错误!", "type":"alarm" });
			     }else if(data.action_status==-1){
			    	 $.showAlert({"content":"操作失败!", "type":"fail" });
			     }else if(data.action_status==1){
			    	 $.showAlert({"content":"激活成功!", "type":"success",
							"callback":function(){location="/purse/my_coupon-11.htm"; 							
							} });
			     }else if(data.action_status==2){
			    	 $.showAlert({"content":"优惠券序列号不存在!", "type":"alarm" });
			     }else if(data.action_status==3){
			    	 $.showAlert({"content":"优惠券序列号过期!", "type":"alarm" });
			     }else if(data.action_status==4){
			    	 $.showAlert({"content":"优惠券序列号已使用!", "type":"alarm" });
			     }else if(data.action_status==5){
			    	 $.showAlert({"content":"优惠券序列号已激活过!", "type":"alarm" });
			     }else if(data.action_status==6){
			    	 $.showAlert({"content":"用户不符合优惠券活动范围!", "type":"alarm" });
			     }else if(data.action_status==7){
			    	 $.showAlert({"content":"超出每日领券限制!", "type":"alarm" });
			     }else if(data.action_status==8){
			    	 $.showAlert({"content":"超出活动领券限制!", "type":"alarm" });
			     }else if(data.action_status==9){
			    	 $.showAlert({"content":"限新用户领取!", "type":"alarm" });
			     }else if(data.action_status==10){
			    	 $.showAlert({"content":"限CLUB会员领取!", "type":"alarm" });
			     }else if(data.action_status==11){
			    	 $.showAlert({"content":"限酒虫及以上级别用户领取!", "type":"alarm" });
			     }else if(data.action_status==12){
			    	 $.showAlert({"content":"限酒鬼及以上级别用户领取!", "type":"alarm" });
			     }else if(data.action_status==13){
			    	 $.showAlert({"content":"限酒圣及以上级别用户领取!", "type":"alarm" });
			     }else if(data.action_status==14){
			    	 $.showAlert({"content":"限酒神及以上级别用户领取!", "type":"alarm" });
			     }else if(data.action_status==15){
			    	 $.showAlert({"content":"限酒仙级别用户领取!", "type":"alarm" });
			     }else if(data.action_status==16){
			    	 $.showAlert({"content":"活动未开始!", "type":"alarm" });
			     }else if(data.action_status==17){
			    	 $.showAlert({"content":"活动已结束!", "type":"alarm" });
			     }else{
			    	 $.showAlert({"content":"错误", "type":"alarm" });
			     }
				 changeCheckCode();
             },
             error:function(){
                changeCheckCode();
             }
	     });
   }