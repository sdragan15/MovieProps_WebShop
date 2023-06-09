import { useEffect, useRef, useState } from "react";
import styles from "../../styles/addProduct.module.css";
import MyInput from "../input-comp/myInput";
import ItemService from "../../services/item.service";
import { ItemModel } from "../../models/item.model";
import { resolvePath } from "react-router-dom";
import CartItem from "../myCart-comp/cartItem";
import UserService from "../../services/user.service";
import { toast } from "react-toastify";

function AddProduct() {
	const itemService = new ItemService();
	const userService = new UserService();

	const [item, setItem] = useState(new ItemModel());
	const [image, setImage] = useState(null);
	const [myItems, setMyItems] = useState([]);
	const [isUploaded, setIsUploaded] = useState();

	const uploadData = (e) => {
		e.preventDefault();

		if (item.name == "") {
			toast.error("Name is required");
			return;
		}
		if (item.price <= 0) {
			toast.error("Invalid price");
			return;
		}
		if (item.quantity <= 0) {
			toast.error("Invalid quantity");
			return;
		}

		const formData = new FormData();
		formData.append("image", image);
		formData.append("name", item.name);
		formData.append("description", item.description);
		formData.append("price", item.price);
		formData.append("quantity", item.quantity);

		itemService
			.addItem(formData)
			.then((response) => {
				if (response.status == 200) {
					toast.success("Success");
					setIsUploaded(true);
				} else {
					console.log(response.message);
				}
			})
			.catch((error) => {
				console.log(error.message);
			});
	};

	const updateItem = (e) => {
		e.preventDefault();

		if (item.name == "") {
			toast.error("Name is required");
			return;
		}
		if (item.price <= 0) {
			toast.error("Invalid price");
			return;
		}
		if (item.quantity <= 0) {
			toast.error("Invalid quantity");
			return;
		}

		const formData = new FormData();
		formData.append("id", item.id);
		formData.append("image", image);
		formData.append("name", item.name);
		formData.append("description", item.description);
		formData.append("price", item.price);
		formData.append("quantity", item.quantity);
		formData.append("lastUpdateTime", item.lastUpdateTime);

		itemService.updateItem(formData).then((response) => {
			if (response.status == 200) {
				toast.success("success");
				setIsUploaded(true);
			}
		});
	};

	useEffect(() => {
		userService
			.getAllItems()
			.then((response) => {
				if (response.status == 200) {
					setMyItems(response.data.data);
				}
			})
			.catch((error) => {
				console.log(error);
			});
	}, [isUploaded]);

	useEffect(() => {
		if (image != null) {
			const temp = URL.createObjectURL(image);
			setItem((prevState) => ({
				...prevState,
				image: temp,
			}));
		}
	}, [image]);

	const onImageChange = (e) => {
		setImage(e.target.files[0]);
	};

	const onEdit = (item) => {
		setItem(item);
	};

	const onDelete = (item) => {
		console.log(item.id);
		itemService
			.deleteItem(item.id)
			.then((response) => {
				if (response.status == 200) {
					toast.success("success");
					setIsUploaded(true);
				}
			})
			.catch((error) => {
				console.log(error);
			});
	};

	return (
		<>
			<div className={styles.addProductWrapper}>
				<form method="post" className={styles.form} onSubmit={uploadData}>
					<div className={styles.productFormContainer}>
						<div className={styles.productInputs}>
							<span>Product name:</span>
							<MyInput
								name={"name"}
								type={"text"}
								value={item.name}
								onChange={(e) =>
									setItem((prevState) => ({
										...prevState,
										name: e.target.value,
									}))
								}
							/>
							<span>Description:</span>
							<MyInput
								name={"description"}
								type={"textarea"}
								value={item.description}
								maxWidth={"25"}
								maxHeight={"20"}
								onChange={(e) =>
									setItem((prevState) => ({
										...prevState,
										description: e.target.value,
									}))
								}
							/>
							<span>Price (rsd):</span>
							<MyInput
								value={item.price}
								name={"price"}
								type={"number"}
								onChange={(e) =>
									setItem((prevState) => ({
										...prevState,
										price: e.target.value,
									}))
								}
							/>
							<span>Quantity:</span>
							<MyInput
								value={item.quantity}
								name={"quantity"}
								type={"number"}
								onChange={(e) =>
									setItem((prevState) => ({
										...prevState,
										quantity: e.target.value,
									}))
								}
							/>
						</div>
						<div className={styles.productImage}>
							<img className={styles.img} src={item.image}></img>
							<input
								className={styles.imageInput}
								type="file"
								accept="image/*"
								onChange={onImageChange}
							></input>
						</div>
					</div>
					<div className={styles.submit}>
						{item.id == 0 && <button className="submit-btn">Add</button>}
						{item.id != 0 && (
							<button onClick={updateItem} className="submit-btn">
								Update
							</button>
						)}
						{item.id != 0 && (
							<button
								onClick={() => {
									setItem(new ItemModel());
								}}
								className="submit-btn cancel-submit"
							>
								Cancel
							</button>
						)}
					</div>
				</form>
				<div className={styles.cardWrapper}>
					<div className="cart-item-container">
						{myItems.map((item) => (
							<CartItem
								key={item.id}
								item={item}
								isEdit={true}
								isDelete={true}
								onEdit={onEdit}
								onDelete={onDelete}
							/>
						))}
					</div>
				</div>
			</div>
		</>
	);
}

export default AddProduct;
