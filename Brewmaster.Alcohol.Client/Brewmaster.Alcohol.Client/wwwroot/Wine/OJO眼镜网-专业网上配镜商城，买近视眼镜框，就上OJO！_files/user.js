/* $Id : user.js 4865 2007-01-31 14:04:10Z paulgao $ */
/* ojoalert框 */

var btnFn = function( ){
	return true;
};

function ojoalert(msg){
	easyDialog.open({
		container : {
			header : 'OJO友情提示您',
			content : msg,
			yesFn : btnFn,
			
		},
		fixed : true
	});
};
/* *
 * 修改会员信息
 */
function userEdit()
{
  var frm = document.forms['formEdit'];
  //var email = frm.elements['email'].value;
  var msg = '';
  var reg = null;
  var passwd_answer = frm.elements['passwd_answer'] ? Utils.trim(frm.elements['passwd_answer'].value) : '';
  var sel_question =  frm.elements['sel_question'] ? Utils.trim(frm.elements['sel_question'].value) : '';

  /*if (email.length == 0)
  {
    msg += email_empty + '<br\>';
  }
  else
  {
    if ( ! (Utils.isEmail(email)))
    {
      msg += email_error + '<br\>';
    }
  }*/

  if (passwd_answer.length > 0 && sel_question == 0 || document.getElementById('passwd_quesetion') && passwd_answer.length == 0)
  {
    msg += no_select_question + '<br\>';
  }

  for (i = 7; i < frm.elements.length - 2; i++)	// 从第七项开始循环检查是否为必填项
  {
	needinput = document.getElementById(frm.elements[i].name + 'i') ? document.getElementById(frm.elements[i].name + 'i') : '';

	if (needinput != '' && frm.elements[i].value.length == 0)
	{
	  msg += '- ' + needinput.innerHTML + msg_blank + '<br\>';
	}
  }

  if (msg.length > 0)
  {
    ojoalert(msg);
    return false;
  }
  else
  {
    return true;
  }
}


/* 会员修改密码 */
function editPassword()
{
  var frm              = document.forms['formPassword'];
  var old_password     = frm.elements['old_password'].value;
  var new_password     = frm.elements['new_password'].value;
  var confirm_password = frm.elements['comfirm_password'].value;

  var msg = '';
  var reg = null;

  if (old_password.length == 0)
  {
    msg += old_password_empty + '<br\>';
  }

  if (new_password.length == 0)
  {
    msg += new_password_empty + '<br\>';
  }

  if (confirm_password.length == 0)
  {
    msg += confirm_password_empty + '<br\>';
  }

  if (new_password.length > 0 && confirm_password.length > 0)
  {
    if (new_password != confirm_password)
    {
      msg += both_password_error + '<br\>';
    }
  }

  if (msg.length > 0)
  {
    ojoalert(msg);
    return false;
  }
  else
  {
    return true;
  }
}

/* 第三方短信功能_新增加 开始 by www.edait.cn */
/* 会员绑定手机 */
function bindMobile()
{
  var frm        = document.forms['formBindmobile'];
  var mobile     = frm.elements['mobile'].value;
  var verifycode = frm.elements['verifycode'].value;

  var msg = '';
  var reg = null;

  if (mobile.length == 0)
  {
    msg += '手机号不能为空！\n';
  }

  if (mobile.length != 11)
  {
    msg += '手机号必须为11位！\n';
  }

  if (verifycode.length == 0)
  {
    msg += '验证码不能为空！\n';
  }

  if (verifycode.length != 6)
  {
    msg += '验证码必须为6位！\n';
  }

  if (msg.length > 0)
  {
    alert(msg);
    return false;
  }
  else
  {
    return true;
  }
}

function mbindMobile()
{
  var frm        = document.forms['formBindmobile'];
  var mobile     = frm.elements['mobile'].value;
  var verifycode = frm.elements['verifycode'].value;
   var checked_agreement = frm.elements['agreement'].checked;

  var msg = '';
  var reg = null;

  if (mobile.length == 0)
  {
    msg += '手机号不能为空！<br\>';
  }

  if (mobile.length != 11)
  {
    msg += '手机号必须为11位<br\>';
  }

  if (verifycode.length == 0)
  {
    msg += '验证码不能为空！<br\>';
  }

  if (verifycode.length != 6)
  {
    msg += '验证码必须为6位<br\>';
  }
  if(checked_agreement != true)
  {
    msg += '请先同意OJO眼镜网用户注册协议！<br\>';
  }
  if (msg.length > 0)
  {
    ojoalert(msg);
    return false;
  }
  else
  {
    return true;
  }
}
/* 第三方短信功能_新增加 结束 by www.edait.cn */

function bindEmail()
{
  var frm        = document.forms['formBindemail'];
  var email     = frm.elements['email'].value;
/*  var verifycode = frm.elements['verifycode'].value;
*/
  var msg = '';
  var reg = null;

  if (email.length == 0)
  {
    msg += '邮箱不能为空！\n';
  }

  if(!Utils.isEmail(email)) {
	  msg += '邮箱格式不正确！\n';
  }


  /*if (verifycode.length == 0)
  {
    msg += '验证码不能为空！\n';
  }

  if (verifycode.length != 6)
  {
    msg += '验证码必须为6位！\n';
  }*/

  if (msg.length > 0)
  {
    ojoalert(msg);
    return;
  }
  frm.submit();
}
/* *
 * 对会员的留言输入作处理
 */
function submitMsg()
{
  var frm         = document.forms['formMsg'];
  var msg_title   = frm.elements['msg_title'].value;
  var msg_content = frm.elements['msg_content'].value;
  var msg = '';

  if (msg_title.length == 0)
  {
    msg += msg_title_empty + '<br\>';
  }
  if (msg_content.length == 0)
  {
    msg += msg_content_empty + '<br\>'
  }

  if (msg_title.length > 200)
  {
    msg += msg_title_limit + '<br\>';
  }

  if (msg.length > 0)
  {
    ojoalert(msg);
    return false;
  }
  else
  {
    return true;
  }
}

/* 第三方短信功能_新增加 开始 by www.edait.cn */
/* *
 * 会员找回密码时，对输入作处理
 */
function submitPwdMobileInfo()
{
  var frm = document.forms['getPasswordByMobile'];
  var user_name = frm.elements['user_name'].value;
  var mobile     = frm.elements['mobile'].value;

  var errorMsg = '';
  if (user_name.length == 0)
  {
    errorMsg += user_name_empty + '\n';
  }

  if (mobile.length == 0)
  {
    errorMsg += mobile_address_empty + '\n';
  }
  else
  {
    if ( ! (Utils.isMobile(mobile)))
    {
      errorMsg += mobile_address_error + '\n';
    }
  }

  if (errorMsg.length > 0)
  {
    alert(errorMsg);
    return false;
  }

  return true;
}
/* 第三方短信功能_新增加 结束 by www.edait.cn */

/* *
 * 会员找回密码时，对输入作处理
 */
function submitPwdInfo()
{
  var frm = document.forms['getPassword'];
  var user_name = frm.elements['user_name'].value;
  var email     = frm.elements['email'].value;

  var errorMsg = '';
  if (user_name.length == 0)
  {
    errorMsg += user_name_empty + '<br\>';
  }

  if (email.length == 0)
  {
    errorMsg += email_address_empty + '<br\>';
  }
  else
  {
    if ( ! (Utils.isEmail(email)))
    {
      errorMsg += email_address_error + '<br\>';
    }
  }

  if (errorMsg.length > 0)
  {
    ojoalert(errorMsg);
    return false;
  }

  return true;
}

/* *
 * 会员找回密码时，对输入作处理
 */
function submitPwd()
{
  var frm = document.forms['getPassword2'];
  var password = frm.elements['new_password'].value;
  var confirm_password = frm.elements['confirm_password'].value;

  var errorMsg = '';
  if (password.length == 0)
  {
    errorMsg += new_password_empty + '<br\>';
  }

  if (confirm_password.length == 0)
  {
    errorMsg += confirm_password_empty + '<br\>';
  }

  if (confirm_password != password)
  {
    errorMsg += both_password_error + '<br\>';
  }

  if (errorMsg.length > 0)
  {
    ojoalert(errorMsg);
    return false;
  }
  else
  {
    return true;
  }
}

/* *
 * 处理会员提交的缺货登记
 */
function addBooking()
{
  var frm  = document.forms['formBooking'];
  var goods_id = frm.elements['id'].value;
  var rec_id  = frm.elements['rec_id'].value;
  var number  = frm.elements['number'].value;
  var desc  = frm.elements['desc'].value;
  var linkman  = frm.elements['linkman'].value;
  var email  = frm.elements['email'].value;
  var tel  = frm.elements['tel'].value;
  var msg = "";

  if (number.length == 0)
  {
    msg += booking_amount_empty + '<br\>';
  }
  else
  {
    var reg = /^[0-9]+/;
    if ( ! reg.test(number))
    {
      msg += booking_amount_error + '<br\>';
    }
  }

  if (desc.length == 0)
  {
    msg += describe_empty + '<br\>';
  }

  if (linkman.length == 0)
  {
    msg += contact_username_empty + '<br\>';
  }

  if (email.length == 0)
  {
    msg += email_empty + '<br\>';
  }
  else
  {
    if ( ! (Utils.isEmail(email)))
    {
      msg += email_error + '<br\>';
    }
  }

  if (tel.length == 0)
  {
    msg += contact_phone_empty + '<br\>';
  }

  if (msg.length > 0)
  {
    ojoalert(msg);
    return false;
  }

  return true;
}

/* *
 * 会员登录
 */
function userLogin()
{
  var frm      = document.forms['formLogin'];
  var username = frm.elements['username'].value;
  var password = frm.elements['password'].value;
   var captcha = frm.elements['captcha'].value;
  var msg = '';

  if (username.length == 0)
  {
    msg += username_empty + '<br\>';
  }

  if (password.length == 0)
  {
    msg += password_empty + '<br\>';
  }
 if (captcha.length == 0)
  {
    msg += '-请输入验证码' + '<br\>';
  }
  if (msg.length > 0)
  {
    ojoalert(msg);
    return false;
  }
  else
  {
    return true;
  }
}

function chkstr(str)
{
  for (var i = 0; i < str.length; i++)
  {
    if (str.charCodeAt(i) < 127 && !str.substr(i,1).match(/^\w+$/ig))
    {
      return false;
    }
  }
  return true;
}




function signIn()
{
  var frm = document.forms['formLogin'];

  if (frm)
  {
    var username = frm.elements['username'].value;
    var password = frm.elements['password'].value;
    var captcha = frm.elements['captcha'].value;
       Ajax.call('/user.php?act=signin', 'username=' + username + '&password=' + encodeURIComponent(password) + '&captcha=' + captcha, signinResponse, "POST", "TEXT");
    
  }
  else
  {
	ojoalert('出错啦！');
  }
}

function signinResponse(result)
{
  var res   = result.parseJSON();

  if (res.error > 0)
  {
	ojoalert(res.content);
    }
    else
    {
      location.href = "/user.php";
    }
		
  }









var ojoflag1=false;
var ojoflag2=false;
var ojoflag3=false;
var ojoflag4=false;
var ojoflag5=false;
function check_password( password )
{
    if ( password.length < 6 )
    {
        document.getElementById('password_notice').innerHTML = password_shorter;
				 document.getElementById('password_notice').style.color = 'red';

		ojoflag1=false;
		return false;	
    }
    else
    {
        document.getElementById('password_notice').innerHTML = msg_can_rg;
		 document.getElementById('password_notice').style.color = 'green';
		ojoflag1=true;
    }
}

function check_conform_password( conform_password )
{
    password = document.getElementById('password1').value;
    
    if ( conform_password.length < 6 )
    {
        document.getElementById('conform_password_notice').innerHTML = password_shorter;
				 document.getElementById('conform_password_notice').style.color = 'red';
        ojoflag2=false;
		return false;	
    }
    if ( conform_password != password )
    {
        document.getElementById('conform_password_notice').innerHTML = confirm_password_invalid;
		 document.getElementById('conform_password_notice').style.color = 'red';
		ojoflag2=false;
		return false;	
    }
    else
    {
        document.getElementById('conform_password_notice').innerHTML = msg_can_rg;
		 document.getElementById('conform_password_notice').style.color = 'green';
		ojoflag2=true;
    }
}

function is_registered( username )
{
   
	var unlen = username.replace(/[^\x00-\xff]/g, "**").length;

    if ( username == '' )
    {
        document.getElementById('username_notice').innerHTML = msg_un_blank;
			document.getElementById('username_notice').style.color = 'red';

        ojoflag3=false;
		return false;	
    }

    if ( !chkstr( username ) )
    {
        document.getElementById('username_notice').innerHTML = msg_un_format;
		document.getElementById('username_notice').style.color = 'red';
        ojoflag3=false;
		return false;	
    }
    if ( unlen < 3 )
    { 
        document.getElementById('username_notice').innerHTML = username_shorter;
		document.getElementById('username_notice').style.color = 'red';
         ojoflag3=false;
		 return false;	
    }
    if ( unlen > 14 )
    {
        document.getElementById('username_notice').innerHTML = msg_un_length;
		document.getElementById('username_notice').style.color = 'red';
         ojoflag3=false;
		 return false;	
    }
  
    Ajax.call( '/user.php?act=is_registered', 'username=' + username, registed_callback , 'GET', 'TEXT', true, true );
}



function registed_callback(result)
{
  if ( result == "true" )
  {
    document.getElementById('username_notice').innerHTML = msg_can_rg;
	document.getElementById('username_notice').style.color = 'green';
    ojoflag3=true;
  }
  else
  {
    document.getElementById('username_notice').innerHTML = '用户名已经存在,请重新输入';
	document.getElementById('username_notice').style.color = 'red';
     ojoflag3=false;
	 return false;	
  }
}

function checkEmail(email)
{

  
  if (email == '')
  {
    document.getElementById('email_notice').innerHTML = msg_email_blank;
	document.getElementById('email_notice').style.color = 'red';
    ojoflag4=false;
	return false;	
  }
  else if (!Utils.isEmail(email))
  {
    document.getElementById('email_notice').innerHTML = msg_email_format;
	document.getElementById('email_notice').style.color = 'red';
   ojoflag4=false;
   return false;	
  }
 
 
  Ajax.call( '/user.php?act=check_email', 'email=' + email, check_email_callback , 'GET', 'TEXT', true, true );
}

function check_email_callback(result)
{
  if ( result == 'ok' )
  {
    document.getElementById('email_notice').innerHTML = msg_can_rg;
	document.getElementById('email_notice').style.color = 'green';
    ojoflag4=true;
  }
  else
  {
    document.getElementById('email_notice').innerHTML = msg_email_registered;
	document.getElementById('email_notice').style.color = 'red';
   ojoflag4=false;
   return false;	
  }
}
/* *
 * ajax验证验证码
 */
 function checkcaptcha(){
	 var captcha = document.getElementById('register_captcha').value;
	  Ajax.call( '/user.php?act=check_captcha', 'captcha=' + captcha, check_captcha_callback , 'GET', 'TEXT', true, true );
	}
 function check_captcha_callback(result)
 {
  if ( result == 'ok' )
  {
  document.getElementById('captcha_notice').innerHTML = '- 验证码正确';
  document.getElementById('captcha_notice').style.color = 'green';
   ojoflag5=true;
  }
  else
  {
   document.getElementById('captcha_notice').innerHTML ='- 验证码错误';
     document.getElementById('captcha_notice').style.color = 'red';
     ojoflag5=false;
  }
}
 

/* *
 * 处理注册用户
 */
function register()
{
  var frm  = document.forms['formUser'];
  var username  = Utils.trim(frm.elements['username'].value);
  var password  = Utils.trim(frm.elements['password'].value);
  var confirm_password = Utils.trim(frm.elements['confirm_password'].value);
  var checked_agreement = frm.elements['agreement'].checked;
  var msn = frm.elements['extend_field1'] ? Utils.trim(frm.elements['extend_field1'].value) : '';
  var qq = frm.elements['extend_field2'] ? Utils.trim(frm.elements['extend_field2'].value) : '';
  var home_phone = frm.elements['extend_field4'] ? Utils.trim(frm.elements['extend_field4'].value) : '';
  var office_phone = frm.elements['extend_field3'] ? Utils.trim(frm.elements['extend_field3'].value) : '';
  var mobile_phone = frm.elements['extend_field5'] ? Utils.trim(frm.elements['extend_field5'].value) : '';
  var passwd_answer = frm.elements['passwd_answer'] ? Utils.trim(frm.elements['passwd_answer'].value) : '';
  var sel_question =  frm.elements['sel_question'] ? Utils.trim(frm.elements['sel_question'].value) : '';
  var captcha = frm.elements['captcha'].value;
  var sms_verifycode = frm.elements['sms_verifycode'].value;

  var msg = "";
  // 检查输入
  var msg = '';
  if (username.length == 0)
  {
    msg += username_empty + '<br\>';
  }
  else if (username.match(/^\s*$|^c:\\con\\con$|[%,\'\*\"\s\t\<\>\&\\]/))
  {
    msg += username_invalid + '<br\>';
  }
  else if (username.length < 3)
  {
    //msg += username_shorter + '<br\>';
  }

 
  if (password.length == 0)
  {
    msg += password_empty + '<br\>';
  }
  else if (password.length < 6)
  {
    msg += password_shorter + '<br\>';
  }
  if (/ /.test(password) == true)
  {
	msg += passwd_balnk + '<br\>';
  }
  if (confirm_password != password )
  {
    msg += confirm_password_invalid + '<br\>';
  }
  if(checked_agreement != true)
  {
    msg += agreement + '<br\>';
  }

  if (msn.length > 0 && (!Utils.isEmail(msn)))
  {
    msg += msn_invalid + '<br\>';
  }

  if (qq.length > 0 && (!Utils.isNumber(qq)))
  {
    msg += qq_invalid + '<br\>';
  }

  if (office_phone.length>0)
  {
    var reg = /^[\d|\-|\s]+$/;
    if (!reg.test(office_phone))
    {
      msg += office_phone_invalid + '<br\>';
    }
  }
  if (home_phone.length>0)
  {
    var reg = /^[\d|\-|\s]+$/;

    if (!reg.test(home_phone))
    {
      msg += home_phone_invalid + '<br\>';
    }
  }
  if (mobile_phone.length>0)
  {
    var reg = /^[\d|\-|\s]+$/;
    if (!reg.test(mobile_phone))
    {
      msg += mobile_phone_invalid + '<br\>';
    }
  }
  if (passwd_answer.length > 0 && sel_question == 0 || document.getElementById('passwd_quesetion') && passwd_answer.length == 0)
  {
    msg += no_select_question + '<br\>';
  }

  for (i = 4; i < frm.elements.length - 4; i++)	// 从第五项开始循环检查是否为必填项
  {
	needinput = document.getElementById(frm.elements[i].name + 'i') ? document.getElementById(frm.elements[i].name + 'i') : '';

	if (needinput != '' && frm.elements[i].value.length == 0)
	{
	  msg += '- ' + needinput.innerHTML + msg_blank + '<br\>';
	}
  }
 if( captcha.length ==0){ msg += '- 验证码不能为空'+ '<br\>';} 
  if( sms_verifycode.length ==0){ msg += '- 短信验证码不能为空'+ '<br\>';} 
 
  if (msg.length > 0)
  {
    ojoalert(msg);
    return false;
  }
  else if(ojoflag1==true &&ojoflag2==true &&ojoflag3==true &&ojoflag5==true){
		return true;
		}else{
		return false;	
			}
}

/* *
 * 用户中心订单保存地址信息
 */
function saveOrderAddress(id)
{
  var frm           = document.forms['formAddress'];
  var consignee     = frm.elements['consignee'].value;
  var email         = frm.elements['email'].value;
  var address       = frm.elements['address'].value;
  var zipcode       = frm.elements['zipcode'].value;
  var tel           = frm.elements['tel'].value;
  var mobile        = frm.elements['mobile'].value;
  var sign_building = frm.elements['sign_building'].value;
  var best_time     = frm.elements['best_time'].value;

  if (id == 0)
  {
    ojoalert(current_ss_not_unshipped);
    return false;
  }
  var msg = '';
  if (address.length == 0)
  {
    msg += address_name_not_null + "<br\>";
  }
  if (consignee.length == 0)
  {
    msg += consignee_not_null + "<br\>";
  }

  if (msg.length > 0)
  {
    ojoalert(msg);
    return false;
  }
  else
  {
    return true;
  }
}

/* *
 * 会员余额申请
 */
function submitSurplus() {
	var frm = document.forms['formSurplus'];
	var surplus_type = frm.elements['surplus_type'].value;
	var surplus_amount = frm.elements['amount'].value;
	var process_notic = frm.elements['user_note'].value;
	var real_name = frm.elements['real_name'].value;
	var account_type = frm.elements['account_type'].value;
	var account = frm.elements['account'].value;
	var mobile_phone = frm.elements['mobile_phone'].value;

	var payment_id = 0;
	var msg = '';

	if (surplus_amount.length == 0) {
		msg += surplus_amount_empty + "<br>";
	} else {
		var reg = /^[\.0-9]+/;
		if (!reg.test(surplus_amount)) {
			msg += surplus_amount_error + '<br>';
		}
	}

	if (process_notic.length == 0 && surplus_type == 0) {
		msg += process_desc + "<br>";
	}
	
	if (real_name.length == 0) {
		msg += "请输入真实姓名！<br>";
	}
	
	if (account_type.length == 0) {
		msg += "请选择账号类型！<br>";
	}
	if (account.length == 0) {
		msg += "请输入收款账号！<br>";
	}
	if (account_type=='银行卡') {
		if(Utils.isEmpty(frm.elements['payment'].value))
		{
			msg += "请输入银行名称！<br>";
		}
	}
	
	
	if (mobile_phone.length == 0) {
		msg += "请输入手机号码！<br>";
	}else {
		if (!(Utils.isMobile(mobile_phone))) {
			msg += "请输入正确的手机号码！<br>";
		}
	}

	if (msg.length > 0) {
		ojoalert(msg);
		return false;
	}

	if (surplus_type == 0) {
		for (var i = 0; i < frm.elements.length; i++) {
			if (frm.elements[i].name == "payment_id" && frm.elements[i].checked) {
				payment_id = frm.elements[i].value;
				break;
			}
		}
		if (payment_id == 0) {
			ojoalert(payment_empty);
			return false;
		}
	}

	return true;
}

/* *
 *  处理用户添加一个红包
 */
function addBonus()
{
  var frm      = document.forms['addBouns'];
  var bonus_sn = frm.elements['bonus_sn'].value;

  if (bonus_sn.length == 0)
  {
    ojoalert(bonus_sn_empty);
    return false;
  }
  else
  {
    var reg = /^[0-9]{10}$/;
    if ( ! reg.test(bonus_sn))
    {
      ojoalert(bonus_sn_error);
      return false;
    }
  }

  return true;
}

/* *
 *  合并订单检查
 */
function mergeOrder()
{
  if (!confirm(confirm_merge))
  {
    return false;
  }

  var frm        = document.forms['formOrder'];
  var from_order = frm.elements['from_order'].value;
  var to_order   = frm.elements['to_order'].value;
  var msg = '';

  if (from_order == 0)
  {
    msg += from_order_empty + '<br\>';
  }
  if (to_order == 0)
  {
    msg += to_order_empty + '<br\>';
  }
  else if (to_order == from_order)
  {
    msg += order_same + '<br\>';
  }
  if (msg.length > 0)
  {
    ojoalert(msg);
    return false;
  }
  else
  {
    return true;
  }
}

/* *
 * 订单中的商品返回购物车
 * @param       int     orderId     订单号
 */
function returnToCart(orderId)
{
  Ajax.call('/user.php?act=return_to_cart', 'order_id=' + orderId, returnToCartResponse, 'POST', 'JSON');
}

function returnToCartResponse(result)
{
  ojoalert(result.message);
}

/* *
 * 检测密码强度
 * @param       string     pwd     密码
 */
function checkIntensity(pwd)
{
  var Mcolor = "#FFF",Lcolor = "#FFF",Hcolor = "#FFF";
  var m=0;

  var Modes = 0;
  for (i=0; i<pwd.length; i++)
  {
    var charType = 0;
    var t = pwd.charCodeAt(i);
    if (t>=48 && t <=57)
    {
      charType = 1;
    }
    else if (t>=65 && t <=90)
    {
      charType = 2;
    }
    else if (t>=97 && t <=122)
      charType = 4;
    else
      charType = 4;
    Modes |= charType;
  }

  for (i=0;i<4;i++)
  {
    if (Modes & 1) m++;
      Modes>>>=1;
  }

  if (pwd.length<=4)
  {
    m = 1;
  }

  switch(m)
  {
    case 1 :
      Lcolor = "2px solid red";
      Mcolor = Hcolor = "2px solid #DADADA";
    break;
    case 2 :
      Mcolor = "2px solid #f90";
      Lcolor = Hcolor = "2px solid #DADADA";
    break;
    case 3 :
      Hcolor = "2px solid #3c0";
      Lcolor = Mcolor = "2px solid #DADADA";
    break;
    case 4 :
      Hcolor = "2px solid #3c0";
      Lcolor = Mcolor = "2px solid #DADADA";
    break;
    default :
      Hcolor = Mcolor = Lcolor = "";
    break;
  }
  if (document.getElementById("pwd_lower"))
  {
    document.getElementById("pwd_lower").style.borderBottom  = Lcolor;
    document.getElementById("pwd_middle").style.borderBottom = Mcolor;
    document.getElementById("pwd_high").style.borderBottom   = Hcolor;
  }


}

function changeType(obj)
{
  if (obj.getAttribute("min") && document.getElementById("ECS_AMOUNT"))
  {
    document.getElementById("ECS_AMOUNT").disabled = false;
    document.getElementById("ECS_AMOUNT").value = obj.getAttribute("min");
    if (document.getElementById("ECS_NOTICE") && obj.getAttribute("to") && obj.getAttribute('fee'))
    {
      var fee = parseInt(obj.getAttribute("fee"));
      var to = parseInt(obj.getAttribute("to"));
      if (fee < 0)
      {
        to = to + fee * 2;
      }
      document.getElementById("ECS_NOTICE").innerHTML = notice_result + to;
    }
  }
}

function calResult()
{
  var amount = document.getElementById("ECS_AMOUNT").value;
  var notice = document.getElementById("ECS_NOTICE");

  reg = /^\d+$/;
  if (!reg.test(amount))
  {
    notice.innerHTML = notice_not_int;
    return;
  }
  amount = parseInt(amount);
  var frm = document.forms['transform'];
  for(i=0; i < frm.elements['type'].length; i++)
  {
    if (frm.elements['type'][i].checked)
    {
      var min = parseInt(frm.elements['type'][i].getAttribute("min"));
      var to = parseInt(frm.elements['type'][i].getAttribute("to"));
      var fee = parseInt(frm.elements['type'][i].getAttribute("fee"));
      var result = 0;
      if (amount < min)
      {
        notice.innerHTML = notice_overflow + min;
        return;
      }

      if (fee > 0)
      {
        result = (amount - fee) * to / (min -fee);
      }
      else
      {
        //result = (amount + fee* min /(to+fee)) * (to + fee) / min ;
        result = amount * (to + fee) / min + fee;
      }

      notice.innerHTML = notice_result + parseInt(result + 0.5);
    }
  }
}

/* *
 * ajax会员登录
 */
 function ajax_user_login(back_history){

	var logform = $('form[name="formLogin"]');
	var username = logform.find('#username');
	var password = logform.find('#password');
	var captcha = logform.find('#authcode');
	var error = logform.find('.msg-wrap');
	var back_act = logform.find("input[name='back_act']").val();

	if(username.val()==''){
		error.css({'visibility':'visible'});
		error.find('.msg-error-text').html('请输入账户名');
		username.parents('.item').addClass('item-error');
		return false;
	}

	if(password.val()==''){
		error.css({'visibility':'visible'});
		password.parents('.item').addClass('item-error');
		error.find('.msg-error-text').html('请输入密码');
		return false;
	}
	
	if(captcha.val()==''){
		error.css({'visibility':'visible'});
		captcha.parents('.item-detail').addClass('item-error');
		error.find('.msg-error-text').html('请输入验证码');
		return false;
	}


	if(back_history){
		Ajax.call( '/user.php?act=ajax_act_login', 'username=' + username.val()+'&password='+password.val()+'&captcha='+captcha.val()+'&back_act='+back_act, return_login_back , 'POST', 'JSON');	
	}else{
		Ajax.call( '/user.php?act=ajax_act_login', 'username=' + username.val()+'&password='+password.val()+'&captcha='+captcha.val()+'&back_act='+back_act, return_login , 'POST', 'JSON');
	}
return false;
}
function return_login(result){
	if(result.error>0){
		$('form[name="formLogin"]').find('.msg-error-text').html(result.message);
        $('#o-authcode').find('img').attr('src','captcha.php?is_login=1&'+Math.random());
		if(result.message != '对不起，您输入的验证码不正确。'){
			$('#authcode').parents('.item-detail').removeClass('item-error');
			$('form[name="formLogin"]').find('.msg-wrap').css('visibility','visible');
		}
		if(result.message == '对不起，您输入的验证码不正确。'){
			$('#authcode').parents('.item-detail').addClass('item-error');
			$('form[name="formLogin"]').find('.msg-wrap').css('visibility','visible');
		}
		if(result.message == '用户名或密码错误'){
			$('#password,#username').parents('.item').addClass('item-error');
			$('form[name="formLogin"]').find('.msg-wrap').css('visibility','visible');
		}
		if(result.message != '用户名或密码错误'){
			$('#password,#username').parents('.item').removeClass('item-error');
			$('form[name="formLogin"]').find('.msg-wrap').css('visibility','visible');
		}
	}else{
		$('.pop-login,.pop-mask').hide();
		$('form[name="formLogin"]').find('.msg-error-text').css('visibility','visible');
		top.location.reload();
	}
}
function return_login_back(result){
	if(result.error>0){
		$('form[name="formLogin"]').find('.msg-error-text').html(result.message);
        $('#o-authcode').find('img').attr('src','captcha.php?is_login=1&'+Math.random());
		if(result.message != '对不起，您输入的验证码不正确。'){
			$('#authcode').parents('.item-detail').removeClass('item-error');
            $('form[name="formLogin"]').find('.msg-wrap').css('visibility','visible');
		}
		if(result.message == '对不起，您输入的验证码不正确。'){
			$('#authcode').parents('.item-detail').addClass('item-error');
            $('form[name="formLogin"]').find('.msg-wrap').css('visibility','visible');
		}
		if(result.message == '用户名或密码错误'){
			$('#password,#username').parents('.item').addClass('item-error');
            $('form[name="formLogin"]').find('.msg-wrap').css('visibility','visible');
		}
		if(result.message != '用户名或密码错误'){
			$('#password,#username').parents('.item').removeClass('item-error');
            $('form[name="formLogin"]').find('.msg-wrap').css('visibility','visible');
		}
	}else{
		$('form[name="formLogin"]').find('.msg-error-text').css('visibility','visible');
        window.location.href = result.url;
	}
}

/* *
 * 验证增加验光单
 */
 
 function check_add_ygd(){
	  var ygd_name        =document.getElementById('ygd_name').value;
	  var ygd_length        =ygd_name.length;
      var right_ds = document.getElementById('right_sphere_id').value;
  var left_ds = document.getElementById('left_sphere_id').value;
  var msg = '';
 if (ygd_length > 10)
  {
    msg += '验光单名称长度不能大于10位' + '<br\>';
  }
  if (ygd_name == 0)
  {
    msg += '验光单名称不能为空' + '<br\>';
  }
  if (right_ds == 0 && left_ds==0)
  {
    msg += '验光单度数不能为空' + '<br\>';
  }
 
  if (msg.length > 0)
  {
    ojoalert(msg);
    return false;
  }
  else
  {
    return true;
  }
	 
	 }
	 
