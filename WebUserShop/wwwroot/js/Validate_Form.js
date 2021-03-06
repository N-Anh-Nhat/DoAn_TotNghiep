(function ($) {
	// validate email
	$.validator.addMethod("validateEmail", function (value, element) {
		return this.optional(element) || /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(value);
	}, "Hãy nhập đúng dịnh dạng Email vd: abc@.com.vn");

	//validate sdt
	$.validator.addMethod("validateSDT", function (value, element) {
		return this.optional(element) || /^[0-9]{10}$/.test(value);
	}, "Hãy nhập đúng định dạng SĐT (10 số)");

	//validate Password
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
	
	//User REGISTER
	$().ready(function () {
		$("#Validate_User").validate({
			rules: {
				"Last_Name": {
					required: true,
					maxlength: 15,
					minlength: 2,
				},
				"Frist_Name": {
					required: true,
					maxlength: 15,
					minlength: 2,
				},
				"UserName": {
					required: true,
					maxlength: 25,
					minlength: 6,
					//validate unique Username
					remote: {
						url: "../../User/GetlstUser",
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
						url: "../../User/GetlstUserofMail",
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
					"url": "../../User/Create",
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
				alert("Tạo tài khoản thành công");
				$("#Validate_User").trigger("reset");
				window.location.reload();
			}
		});
	});


	//user login
	$().ready(function () {
		$("#login").validate({
			rules: {
				"usernameLogin": {
					required: true
				},
				"passwordLogin": {
					required: true
				},	
			},
			messages: {
				"usernameLogin": {
					required: "Không được để trống Tài khoản",
				},
				"passwordLogin": {
					required: "Không được để trống Mật khẩu"
				},
			},
			submitHandler: function () {
				var inputtk = $('#usernameLogin').val();
				var inputmk = $('#passwordLogin').val();
				$.ajax({
					url: "../../User/Login",
					data: { tkLogin: inputtk, mkLogin: inputmk },
					cache: false,
					type: "POST",
					success: function (res) {
						if (res == true) {
							alert("Đăng nhập thành công");
							window.location.reload();
						}
                        else {
							alert("Sai tên tài khoản hoặc mật khẩu");
                        }	
					}
				});
				
			}
		});
	});

	//edit user
	$().ready(function () {
		$("#EditUser").validate({
			rules: {
				"Last_NameUser": {
					required: true,
					maxlength: 15,
					minlength: 2,
				},
				"Frist_NameUser": {
					required: true,
					maxlength: 15,
					minlength: 2,
				},
				"AddressUser": {
					required: true,
					minlength: 10
				},
				"Password": {
					required: true,
					//kiem tra pass co trung k
					remote: {
						url: "../../User/UniquePass",
						type: "get",
						data: {
							Pass: function () {
								return $("#Password").val();
							}
						}
					}
				},
				"NewPassword": {
					required: true,
					validatePassword: true
				},
				"NewRePassword": {
					required: true,
					equalTo: "#NewPassword",

				},
			},
			messages: {
				"Last_NameUser": {
					required: "Không được để trống Họ",
					maxlength: "Tối đa 15 ký tự",
					minlength: "Hãy nhập ít nhất 2 ký tự"
				},
				"Frist_NameUser": {
					required: "Không được để trống Tên",
					maxlength: "Tối đa 15 ký tự",
					minlength: "Hãy nhập ít nhất 2 ký tự"
				},
				"AddressUser": {
					required: "Không được để trống Địa chỉ",
					minlength: "Hãy nhập ít nhất 10 ký tự"
				},
				"Password": {
					required: "Không được để trống Mật khẩu",
					remote: "Mật khẩu sai"
				},
				"NewPassword": {
					required: "Không được để trống Mật khẩu",
				},
				"NewRePassword": {
					required: "Không được để trống Mật khẩu",
					equalTo: "Mật khẩu không khớp"
				},
			},
			submitHandler: function () {
				var hoUser = $('#Last_NameUser').val();
				var tenUser = $('#Frist_NameUser').val();
				var diachiUser = $('#AddressUser').val();
				var emailUser = $('#EmailUser').val();
				var taikhoanUser = $('#tkUserdn').val();
				var sdtUser = $('#PhoneUser').val();
				var matkhauUser = $('#NewPassword').val();
				var idRole = $('#idroleUser').val();
				var idUSer = $('#id').val();
				var data = {
					Last_Name: hoUser,
					Frist_Name: tenUser,
					Address: diachiUser,
					UserName: taikhoanUser,
					Password: matkhauUser,
					Email: emailUser,
					Phone: sdtUser,
					ID_Role: idRole,
					ID: idUSer,
				}
				$.ajax({
					"async": false,
					"crossDomain": true,
					"url": "../TheWayShop/EditAccount",
					"headers": {
						"Content-Type": "application/json",
						"cache-control": "no-cache"
					},
					"method": "POST",
					"data": JSON.stringify(data),
					success: function (res) {
						if (res == true) {
							alert("Sửa thông tin thành công,Vui lòng đăng nhập lại");
							window.location.assign("https://localhost:44369");
						}
					}
				});

			}
		});
	});

	//Comment
	$().ready(function () {
		$("#BinhLuan").validate({
			rules: {
				"message": {
					required: true,
					maxlength: 100,
				},
			},
			messages: {
				"message": {
					required: "Không được để trống Bình luận",
					maxlength:"Tối đa 100 ký tự",
				},
			},
			submitHandler: function () {
				var inputMessage = $('#message').val();
				var inputIdproduct = $('#ID_Product').val();
				var data = {
					ID_Product: inputIdproduct,
					Content_CMT: inputMessage,
				}
				$.ajax({
					"async": false,
					"crossDomain": true,
					"url": "../../User/InsertMessage",
					"headers": {
						"Content-Type": "application/json",
						"cache-control": "no-cache"
					},
					"method": "POST",
					"data": JSON.stringify(data),
					success: function (res) {
						if (res == true) {
							alert("Bình luận sản phẩm thành công");
							window.location.reload();
						}
					}
				});
			}
		});
	});

}(jQuery));
