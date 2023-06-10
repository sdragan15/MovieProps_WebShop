import React from "react";
import FacebookLogin from "react-facebook-login";
import { Link, useNavigate } from "react-router-dom";
import AuthService from "../services/auth.service";
import { toast } from "react-toastify";

const FacebookLoginButton = ({ onLoginSuccess, onLoginFailure }) => {
	const navigate = useNavigate();
	const authService = new AuthService();

	const responseFacebook = async (response) => {
		if (response.accessToken) {
			let data = {
				token: response.accessToken,
			};

			authService
				.loginFacebook(data)
				.then((response) => {
					if (response.status == 200) {
						onLoginSuccess(response.data);
					}
				})
				.catch((error) => {
					onLoginFailure(error);
				});
		} else {
			navigate("/");
			onLoginFailure(response);
		}
	};

	const handleFacebookLogin = async () => {
		await responseFacebook();
	};

	return (
		<FacebookLogin
			appId="148317594919634"
			autoLoad={false}
			fields="name,email,picture"
			callback={responseFacebook} // Bez await ovde
			render={(renderProps) => (
				<button onClick={handleFacebookLogin}>FACEBOOK LOGIN</button>
			)}
		/>
	);
};

export default FacebookLoginButton;
