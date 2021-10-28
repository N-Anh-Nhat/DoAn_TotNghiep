
(function ($) {
	// validate email
	$.validator.addMethod("validateEmail", function (value, element) {
		return this.optional(element) || /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(value);
	}, "Hãy nhập đúng dịnh dạng Email vd: abc@.com.vn");

	//validate name
	$.validator.addMethod("validateName", function (value, element) {
		return this.optional(element) || /^[a-zA-Z]+$/.test(value);
	}, "Tên không được chứa số");

	//validate sdt
	$.validator.addMethod("validateSDT", function (value, element) {
		return this.optional(element) || /^[0-9]{10}$/.test(value);
	}, "Hãy nhập đúng định dạng SĐT (10 số)");

	//validate Pass
	$.validator.addMethod("validatePassword", function (value, element) {
		return this.optional(element) || /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{8,16}$/.test(value);
	}, "Hãy nhập password từ 8 đến 16 ký tự bao gồm chữ hoa, chữ thường và ít nhất một chữ số");



	
	//Feedback
	$().ready(function ()
	{
			$("#Validate_FB").validate({
				rules: {
					"Name": {
						required: true,
						minlength: 2,
						validateName: true
					},
					"Email": {
						required: true,
						validateEmail: true
					},
					"Phone": {
						required: true,
						validateSDT: true
					},
					"Title": {
						required: true,
						minlength: 8
					},
					"Message": {
						required: true,
						minlength: 10
					},
				},
				messages: {
					"Name": {
						required: "Không được để trống Tên",
						minlength: "Tên quá ngắn",
					},
					"Email": {
						required: "Không được để trống Email",
					},
					"Phone": {
						required: "Không được để trống Số điện thoại",
					},
					"Title": {
						required: "Không được để trống Tiêu đề",
						minlength: "Hãy nhập ít nhất 8 ký tự"
					},
					"Message": {
						required: "Không được để trống Nội dung",
						minlength: "Hãy nhập ít nhất 10 ký tự"
					},
				},
				submitHandler: function () {
					var inputName = $('#Name').val();
					var inputEmail = $('#Email').val();
					var inputPhone = $('#SDT').val();
					var inputTitle = $('#Title').val();
					var inputMessage = $('#Message').val();
					var data = {
						Name: inputName,
						Email: inputEmail,
						Phone: inputPhone,
						Title: inputTitle,
						Content: inputMessage,
					}
					$.ajax({
						"async": false,
						"crossDomain": true,
						"url": "../TheWayShop/SendFeedback",
						"headers": {
							"Content-Type": "application/json",
							"cache-control": "no-cache"
						},
						"method": "POST",
						"data": JSON.stringify(data),
						success: function (res) {
							if (res.status == true) {

							}
						}
					});
					alert("Gửi yêu cầu thành công");
					$("#Validate_FB").trigger("reset");
                }
			});
	});
	
	//User
	$().ready(function () {
		$("#Validate_User").validate({
			rules: {
				"Last_Name": {
					required: true,
					maxlength: 15,
					minlength: 2,
					validateName: true
				},
				"Frist_Name": {
					required: true,
					maxlength: 15,
					minlength: 2,
					validateName: true
				},
				"UserName": {
					required: true,
					maxlength: 25,
					minlength: 6,
					//validate unique Username
					remote: {
						url: "../User/GetlstUser",
						type: "get",
						data: {
							User: function () {
								return $("#UserName").val();
							}
						}
					}
				},
				"Password": {
					required: true,
					validatePassword: true
				},
				"RePassword": {
					required: true,
					equalTo:"#Password",
				},
				"Address": {
					required: true,
					minlength: 10
				},
				"Email": {
					required: true,
					validateEmail: true,
					//validate unique Email
					remote: {
						url: "../User/GetlstUserofMail",
						type: "get",
						data: {
							mail: function () {
								return $("#Email").val();
							}
						}
					}
				},
				"Phone": {
					required: true,
					validateSDT: true
				},

			},
			messages: {
				"Last_Name": {
					required: "Không được để trống Họ",
					maxlength: "Tối đa 15 ký tự",
					minlength: "Hãy nhập ít nhất 2 ký tự"
				},
				"Frist_Name": {
					required: "Không được để trống Tên",
					maxlength: "Tối đa 15 ký tự",
					minlength: "Hãy nhập ít nhất 2 ký tự"
				},
				"UserName": {
					required: "Không được để trống Tài khoản",
					maxlength: "Tối đa 25 ký tự",
					minlength: "Hãy nhập ít nhất 6 ký tự",
					remote: "User đã tồn tại"
				},
				"Password": {
					required: "Không được để trống Mật khẩu",
				},
				"RePassword": {
					required: "Không được để trống Mật khẩu",
					equalTo:"Mật khẩu không khớp"
				},
				"Address": {
					required: "Không được để trống Địa chỉ",
					minlength: "Hãy nhập ít nhất 10 ký tự"
				},
				"Email": {
					required: "Không được để trống Email",
					remote: "Email đã tồn tại"
				},
				"Phone": {
					required: "Không được để trống Số điện thoại"
				},
			},
			submitHandler: function () {
				var inputLast_Name = $('#Last_Name').val();
				var inputFrist_Name = $('#Frist_Name').val();
				var inputUserName = $('#UserName').val();
				var inputPassword = $('#Password').val();
				var inputAddress = $('#Address').val();
				var inputEmail = $('#Email').val();
				var inputPhone = $('#Phone').val();
				var data = {
					Last_Name: inputLast_Name,
					Frist_Name: inputFrist_Name,
					UserName: inputUserName,
					Password: inputPassword,
					Address: inputAddress,
					Email: inputEmail,
					Phone: inputPhone
				}
				$.ajax({
					"async": false,
					"crossDomain": true,
					"url": "../User/Create",
					"headers": {
						"Content-Type": "application/json",
						"cache-control": "no-cache"
					},
					"method": "POST",
					"data": JSON.stringify(data),
					success: function (res) {
						if (res.status == true) {

						}
					}
				});
				alert("Gửi yêu cầu thành công");
				$("#Validate_User").trigger("reset");
			}
		});
	});
}(jQuery));
