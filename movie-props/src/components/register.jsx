import styles from "../styles/login.css";
import { Link, useNavigate } from "react-router-dom";
import MyInput from "./input-comp/myInput";
import { useEffect, useState } from "react";
import UserService from "../services/user.service";
import { RegisterModel } from "../models/login.model";
import { RoleModel } from "../models/role.model";
import { toast } from "react-toastify";

function Register() {
	const navigate = useNavigate();
	const userService = new UserService();
	const role = new RoleModel();

	const [register, setRegister] = useState(new RegisterModel());
	const [image, setImage] = useState(null);
	const [imageUrl, setImageUrl] = useState();

	const handleSubmit = (event) => {
		event.preventDefault();

		if (register.email == "") {
			toast.error("E-mail is required");
			return;
		}
		if (register.password == "") {
			toast.error("Password is required");
			return;
		}
		if (register.name == "") {
			toast.error("Firstname is required");
			return;
		}
		if (register.lastname == "") {
			toast.error("Lastname is required");
			return;
		}
		if (register.address == "") {
			toast.error("Address is required");
			return;
		}
		if (register.date == null) {
			toast.error("Date of birth is required");
			return;
		}

		const date = new Date(register.date);
		const formData = new FormData();
		formData.append("firstName", register.name);
		formData.append("lastName", register.lastname);
		formData.append("email", register.email);
		formData.append("password", register.password);
		formData.append("address", register.address);
		formData.append("birthDay", register.date);
		formData.append("role", register.role);
		formData.append("image", image);

		userService
			.register(formData)
			.then((response) => {
				if (response.status == 200) {
					toast.success("Success");
					navigate("../login");
				} else {
					toast.error("Failed");
				}
			})
			.catch((error) => {
				toast.error(error.message);
			});
	};

	useEffect(() => {
		if (image != null) {
			const temp = URL.createObjectURL(image);
			setImageUrl(temp);
		}
	}, [image]);

	const onImageChange = (e) => {
		setImage(e.target.files[0]);
	};

	const onSelect = (e) => {
		setRegister((prevState) => ({
			...prevState,
			role: e.target.value,
		}));
	};

	return (
		<>
			<div className="main-overlay-white"></div>
			<div className="register-container">
				<h1 className="header">Register</h1>
				<div className="register-form-wrapper">
					<form method="post" onSubmit={handleSubmit}>
						<MyInput
							text={"E-mail"}
							type={"email"}
							name={"e-mail"}
							value={register.email}
							onChange={(e) =>
								setRegister((prevState) => ({
									...prevState,
									email: e.target.value,
								}))
							}
						/>
						<div className="register-inputs">
							<div>
								<MyInput
									text={"Username"}
									type={"text"}
									name={"username"}
									value={register.username}
									onChange={(e) =>
										setRegister((prevState) => ({
											...prevState,
											username: e.target.value,
										}))
									}
								/>
								<MyInput
									text={"Name"}
									type={"text"}
									name={"name"}
									value={register.name}
									onChange={(e) =>
										setRegister((prevState) => ({
											...prevState,
											name: e.target.value,
										}))
									}
								/>
								<MyInput
									text={"Address"}
									type={"text"}
									name={"address"}
									value={register.address}
									onChange={(e) =>
										setRegister((prevState) => ({
											...prevState,
											address: e.target.value,
										}))
									}
								/>
								<img className="register-img" src={imageUrl}></img>
							</div>
							<div>
								<MyInput
									text={"Password"}
									type={"password"}
									name={"password"}
									value={register.password}
									onChange={(e) =>
										setRegister((prevState) => ({
											...prevState,
											password: e.target.value,
										}))
									}
								/>
								<MyInput
									text={"Last name"}
									type={"text"}
									name={"lastName"}
									value={register.lastname}
									onChange={(e) =>
										setRegister((prevState) => ({
											...prevState,
											lastname: e.target.value,
										}))
									}
								/>
								<MyInput
									text={"Date of birth"}
									type={"date"}
									name={"date"}
									value={register.date}
									onChange={(e) =>
										setRegister((prevState) => ({
											...prevState,
											date: e.target.value,
										}))
									}
								/>
								<input
									className="register-img-input"
									type="file"
									accept="image/*"
									onChange={onImageChange}
								></input>
							</div>
						</div>
						<div className="register-role-wrapper">
							<select className="register-role" name="role" onChange={onSelect}>
								<option value={role.buyer}>I want to BUY products</option>
								<option value={role.seller}>
									I want to BUY and SELL products
								</option>
							</select>
						</div>

						<div className="submit-wrapper">
							<button className="submit-btn">Register</button>
						</div>
					</form>
					<div className="login-link-wrapper">
						<Link to="../login">Log in</Link>
					</div>
				</div>
			</div>
			<img className="login-photo" src={require("../images/lotrRing.png")} />
		</>
	);
}

export default Register;
