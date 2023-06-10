import { useEffect, useState } from "react";
import styles from "../styles/mainShop.css";
import Item from "./items-comp/item";
import AddItemModal from "./modals-comp/addItemModal";
import { ItemModel } from "../models/item.model";
import ItemService from "../services/item.service";
import { useNavigate } from "react-router-dom";

let itemService = ItemService;

function MainShop() {
	const navigate = useNavigate();
	itemService = new ItemService();

	const [clickedItem, setClickedItem] = useState(null);
	const [show, setShow] = useState(false);
	const [items, setItems] = useState([]);
	const [buyNo, setBuyNo] = useState(0);

	useEffect(() => {
		itemService
			.getAll()
			.then((res) => {
				if (res.status == 200) {
					console.log(res.data.data);
					setItems(res.data.data);
				} else {
					console.log(res.message);
				}
			})
			.catch((error) => {
				console.log(error);
			});
	}, []);

	const openAddItemModal = (event, item) => {
		setBuyNo(0);

		console.log(localStorage["items"]);
		if (localStorage["items"] != "" && localStorage["items"] != undefined) {
			let myItems = [];
			myItems = JSON.parse(localStorage["items"]);
			myItems.forEach((element) => {
				if (element.id == item.id) {
					item.count = element.count;
					setBuyNo(item.count);
				}
			});
		}

		setClickedItem(item);
		setShow(true);
	};

	const addToCart = (no) => {
		if (localStorage["token"] == undefined) {
			navigate("../login");
			return;
		}
		if (no <= 0) {
			return;
		}
		clickedItem.count = no;
		if (localStorage["items"] == "" || localStorage["items"] == undefined) {
			let myItems = [];
			myItems.push(clickedItem);
			localStorage["items"] = JSON.stringify(myItems);
		} else {
			let myItems = [];
			let isUpdate = false;
			console.log(localStorage["items"]);
			myItems = JSON.parse(localStorage["items"]);
			myItems.forEach((element) => {
				if (element.id == clickedItem.id) {
					element.count = clickedItem.count;
					isUpdate = true;
				}
			});
			if (!isUpdate) {
				myItems.push(clickedItem);
			}

			localStorage["items"] = JSON.stringify(myItems);
		}
	};

	return (
		<>
			<div className="shop-wrapper">
				<div className="shop-search-wrapper">
					<input type="text" placeholder="Search" />
				</div>
				<div className="shop-main-wrapper">
					<div className="shop-sidebar">
						<div className="shop-sidebar-item">
							<span>Sort by</span>
							<span>^</span>
						</div>
						<div className="shop-sidebar-item">
							<span>Sort by</span>
							<span>^</span>
						</div>
					</div>
					<div className="shop-items-wrapper">
						{items.map((item) => (
							<Item
								key={item.id}
								name={item.name}
								description={item.description}
								price={item.price}
								image={item.image}
								onClick={(event) => openAddItemModal(event, item)}
							/>
						))}
					</div>
				</div>
			</div>
			{show && (
				<AddItemModal
					setShow={setShow}
					name={clickedItem.name}
					description={clickedItem.description}
					image={clickedItem.image}
					price={clickedItem.price}
					quantity={clickedItem.quantity}
					buyNo={buyNo}
					setByNo={setBuyNo}
					addToCart={addToCart}
				/>
			)}
		</>
	);
}

export default MainShop;
