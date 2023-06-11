import styles from "../styles/login.css";
import { Link, useNavigate } from "react-router-dom";
import MyInput from "./input-comp/myInput";
import { LoginModel } from "../models/login.model";
import { useState } from "react";
import { AuthService } from "../services/auth.service";
import { toast } from "react-toastify";
import FacebookLoginButton from "./facebookLoginButton";

function Login({ onLogIn }) {
	const authService = new AuthService();

	const navigate = useNavigate();

	const [data, setData] = useState(new LoginModel());

	const handleSubmit = (event) => {
		event.preventDefault();

		if (data.email.trim() == "") {
			toast.error("Email is required");
			return;
		}

		if (data.password.trim() == "") {
			toast.error("Password is required");
			return;
		}

		let res = authService
			.login(data)
			.then((response) => {
				if (response.status == 200) {
					localStorage["token"] = response.data;
					localStorage["items"] = "";
					onLogIn(data.email);
					navigate("/main-shop");
				} else {
					toast.error(response.data.message);
				}
			})
			.catch((error) => {
				toast.error(error.message);
			});
	};

	const handleLoginSuccess = (accessToken) => {
		localStorage["token"] = accessToken;
		onLogIn();
		toast.success("Facebook login successfuly!");
		navigate("/main-shop");
	};

	const handleLoginFailure = (error) => {
		toast.error("Facebook login failed.");
	};

	return (
		<>
			<div className="main-overlay-white"></div>
			<div className="login-container">
				<h1 className="header">Log in</h1>
				<div className="login-form-wrapper">
					<form method="post" className="login-form" onSubmit={handleSubmit}>
						<MyInput
							text={"E-mail"}
							type={"email"}
							name={"e-mail"}
							value={data.email}
							onChange={(e) =>
								setData((prevState) => ({
									...prevState,
									email: e.target.value,
								}))
							}
						/>
						<MyInput
							text={"Password"}
							type={"password"}
							name={"password"}
							value={data.password}
							onChange={(e) =>
								setData((prevState) => ({
									...prevState,
									password: e.target.value,
								}))
							}
						/>
						<div className="submit-wrapper">
							<button className="submit-btn">Log in</button>
						</div>
						<div className="submit-wrapper-facebook">
							<FacebookLoginButton
								onLoginSuccess={handleLoginSuccess}
								onLoginFailure={handleLoginFailure}
							/>
							{/* <button className="submit-btn" onClick={loginWithFacebook}>
								Log in with Facebook
							</button> */}
						</div>
					</form>
					<div className="register-wrapper">
						<Link to="/register">Not registered?</Link>
					</div>
				</div>
			</div>
			<img className="login-photo" src={require("../images/lotrRing.png")} />
		</>
	);
}

export default Login;
