$(function(){
	jQuery.validator.addMethod("uri", function(value, element) {
		return this.optional(element)||/^(\/\w+)+\.htm$/.test(value);
	}, "请输入正确的URI");
	jQuery.validator.addMethod("phone", function(value, element) {
//		return this.optional(element)||/^(130|131|132|133|134|135|136|137|138|139|150|153|156|158|159|188|189)\d{8}$/.test(value);
		return this.optional(element)||/^(((\(\d{3,4}\))|(\d{3,4}-))?[1-9]\d{6,7}(-\d{0,4})?)?$/.test(value);
	}, "请输入正确的电话号码(7或8位数字)");
	
	jQuery.validator.addMethod("mobile", function(value, element) {
		return this.optional(element)||mobileRegex_s.test(value); // mobileRegex_s 在user-system项目里面定义
	}, "请输入正确格式的手机号(以13开始或11位数字)");
	
	jQuery.validator.addMethod("zipcode", function(value, element) {
		return this.optional(element)||/^[0-9]\d{5}$/.test(value);
	}, "请输入正确格式邮编(6位数字)");
	
	jQuery.validator.addMethod("qq", function(value, element) {
		return this.optional(element)||/^\d{5,10}$/.test(value);
	}, "请输入正确格式qq(5-10位数字)");
	
	
	jQuery.validator.addMethod("N", function(value, element) {
		return this.optional(element)||/^\d+$/.test(value);
	}, "请输入数字");	
	jQuery.validator.addMethod("float", function(value, element) {
		return this.optional(element)||/^^(?:[1-9][0-9]*(?:\.[0-9]+)?|0(?:\.[0-9]+)?)$/.test(value);
	}, "请输入整数或非负浮点数");
	
	
	jQuery.validator.addMethod("numAndNull", function(value, element) {
		return /(^\d+$)|(^$)/.test(value);
	}, "请输入数字");
	
	jQuery.validator.addMethod("noNull", function(value, element) {
		return /[\w\W]+/.test(value);
	}, "不能为空");
	
	jQuery.validator.addMethod("NandW", function(value, element) {
		return /^[A-Za-z].*[0-9]|[0-9].*[A-Za-z]$/.test(value);
	}, "不能全部为数字或字母");
	
	jQuery.validator.addMethod("Letters", function(value, element) {
		return this.optional(element)||/^[a-z]+$/.test(value);
	}, "必须由字母组成");
	jQuery.validator.addMethod("Price", function(value, element) {
		return this.optional(element)||(/^(([1-9]\d*)|\d)(\.\d{1,2})?$/).test(value);
	}, "请输入正确金额格式");
	
});