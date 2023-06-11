import { useEffect, useState } from "react";
import { UserModel } from "../models/user.model";
import styles from "../styles/profile.module.css";
import MyInput from "./input-comp/myInput";
import UserService from "../services/user.service";

function Profile() {
	const userService = new UserService();

	const [user, setUser] = useState(new UserModel());
	const [image, setImage] = useState(null);

	const getUser = () => {
		userService
			.get()
			.then((response) => {
				if (response.status == 200) {
					let data = new UserModel();
					data = response.data.data;
					if (data.birthDay != null)
						data.birthDay = data.birthDay.split("T")[0];
					setUser(data);
					localStorage["user"] = JSON.stringify(response.data.data);
				} else {
					alert("failed");
				}
			})
			.catch((error) => {
				console.log(error);
			});
	};

	const inputChange = (e) => {
		e.preventDefault();

		const { name, value } = e.target;
		setUser((prevState) => ({
			...prevState,
			[name]: value,
		}));
	};

	useEffect(() => {
		getUser();
		console.log(user);
	}, []);

	useEffect(() => {
		if (image != null) {
			const temp = URL.createObjectURL(image);
			setUser((prevState) => ({
				...prevState,
				image: temp,
			}));
		}
	}, [image]);

	const onImageChange = (e) => {
		setImage(e.target.files[0]);
	};

	const submit = (e) => {
		e.preventDefault();

		const formData = new FormData();
		formData.append("firstName", user.firstName);
		formData.append("lastName", user.lastName);
		formData.append("email", user.email);
		formData.append("address", user.address);
		formData.append("birthDay", user.birthDay);
		formData.append("image", image);

		userService
			.update(formData)
			.then((response) => {
				if (response.status == 200) {
					alert("Success");
					getUser();
				} else {
					alert("Failed");
				}
			})
			.catch((error) => {
				console.log(error);
			});
	};

	return (
		<>
			<div className={styles.backgroundWrapper}>
				<div className={styles.background}></div>
			</div>
			<div className={styles.mainWrapper}>
				<form method="post" onSubmit={submit} className={styles.container}>
					<table className={styles.userTable}>
						<tbody>
							<tr>
								<th>Profile picture:</th>
								<td>
									<div className={styles.imageWrapper}>
										<img className={styles.profilePic} src={user.image}></img>
										<input
											className={styles.imageInput}
											type="file"
											accept="image/*"
											onChange={onImageChange}
										></input>
									</div>
								</td>
							</tr>
							<tr>
								<th>Firstname:</th>
								<td>
									<MyInput
										type={"text"}
										name={"firstName"}
										value={user.firstName}
										onChange={inputChange}
									/>
								</td>
							</tr>
							<tr>
								<th>Lastname:</th>
								<td>
									<MyInput
										type={"text"}
										name={"lastName"}
										value={user.lastName}
										onChange={inputChange}
									/>
								</td>
							</tr>
							<tr>
								<th>E-mail</th>
								<td>
									<MyInput
										type={"text"}
										name={"email"}
										value={user.email}
										onChange={inputChange}
									/>
								</td>
							</tr>
							<tr>
								<th>Address</th>
								<td>
									<MyInput
										type={"text"}
										value={user.address}
										name={"address"}
										onChange={inputChange}
									/>
								</td>
							</tr>
							<tr>
								<th>Date of birth</th>
								<td>
									<MyInput
										type={"date"}
										value={user.birthDay}
										name={"birthDay"}
										onChange={inputChange}
									/>
								</td>
							</tr>
							<tr>
								<td colSpan={2}>
									<div className={styles.saveWrapper}>
										<button className={styles.save}>Save</button>
									</div>
								</td>
							</tr>
						</tbody>
					</table>
				</form>
			</div>
		</>
	);
}

export default Profile;
