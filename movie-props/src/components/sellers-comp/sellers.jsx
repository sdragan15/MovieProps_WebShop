import { useCallback, useEffect, useState } from "react";
import { RoleModel } from "../../models/role.model";
import { UserStatus } from "../../models/user-status.model";
import UserService from "../../services/user.service";
import styles from "../../styles/sellers.module.css";
import { UserModel } from "../../models/user.model";

function Sellers() {
	const status = new UserStatus();
	const userSerivce = new UserService();

	const [users, setUsers] = useState([]);

	const getAllSellers = () => {
		userSerivce
			.getAllSellers()
			.then((response) => {
				if (response.status == 200) {
					setUsers(response.data.data);
					console.log(response.data.data);
				} else {
					alert(response.message);
				}
			})
			.catch((error) => {
				console.log(error);
			});
	};

	useEffect(() => {
		getAllSellers();
	}, []);

	const handleApprove = (email) => {
		userSerivce
			.approveSeller(email)
			.then((response) => {
				if (response.status == 200) {
					alert("success");
					getAllSellers();
				} else {
					alert(response.message);
				}
			})
			.catch((error) => {
				console.log(error);
			});
	};

	const handleReject = (email) => {
		userSerivce
			.rejectSeller(email)
			.then((response) => {
				if (response.status == 200) {
					alert("success");
					getAllSellers();
				} else {
					alert(response.message);
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
				<h1>Sellers</h1>
				<div className={styles.container}>
					<table className={styles.sellersTable}>
						<thead>
							<tr>
								<th>Profile Image</th>
								<th>Username</th>
								<th>Email</th>
								<th>Firstname</th>
								<th>Lastname</th>
								<th>Adress</th>
							</tr>
						</thead>
						<tbody>
							{users.map((user) => (
								<tr key={user.email}>
									<td>
										<img className={styles.profileImg} src={user.image}></img>
									</td>
									<td>dgsaji</td>
									<td>{user.email}</td>
									<td>{user.firstName}</td>
									<td>{user.lastName}</td>
									<td>{user.address}</td>
									<td>
										<div className={styles.aproveColumn}>
											{user.status == status.Pending ? (
												<span
													className={styles.approveBtn}
													onClick={() => {
														handleApprove(user.email);
													}}
												>
													APPROVE
												</span>
											) : null}
											{user.status == status.Pending ? (
												<span
													className={styles.rejectBtn}
													onClick={() => {
														handleReject(user.email);
													}}
												>
													REJECT
												</span>
											) : null}
											{user.status == status.Approved ? (
												<span className={styles.approvedLabel}>APPROVED</span>
											) : null}
											{user.status == status.Rejected ? (
												<span className={styles.rejectedLabel}>REJECTED</span>
											) : null}
										</div>
									</td>
								</tr>
							))}
						</tbody>
					</table>
				</div>
			</div>
		</>
	);
}

export default Sellers;
