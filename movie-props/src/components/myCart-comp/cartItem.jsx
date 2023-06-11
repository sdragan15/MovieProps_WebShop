import styles from "../../styles/myCart.css";

function CartItem({
	item,
	isBuyNo,
	isDelete,
	isEdit,
	isOnlyShow,
	onEdit,
	onDelete,
	count,
}) {
	const handleEdit = () => {
		onEdit(item);
	};

	const handleDelete = () => {
		onDelete(item);
	};

	let buyNoComp = (
		<>
			<div className="quantity item">
				<span className="quantity-simbol">-</span>
				<span className="quantity-no">{item?.count}</span>
				<span className="quantity-simbol">+</span>
			</div>
		</>
	);

	let editComp = (
		<>
			<span onClick={handleEdit} className="cart-edit">
				Edit
			</span>
		</>
	);

	let deleteComp = (
		<>
			<span onClick={handleDelete} className="cart-edit">
				Delete
			</span>
		</>
	);

	let onlyShow = (
		<>
			<div className="quantity item">
				<span>Count:</span>
				<span className="quantity-no">{count}</span>
			</div>
		</>
	);

	return (
		<>
			<div className="cart-item">
				<img className="cart-image" src={item?.image}></img>
				<span className="cart-name item">{item?.name}</span>
				<span className="cart-description">{item?.description}</span>
				<span className="cart-price">${item?.price}</span>
				<div className="cart-end">
					{isBuyNo && buyNoComp}
					{isEdit && editComp}
					{isDelete && deleteComp}
					{isOnlyShow && onlyShow}
				</div>
			</div>
		</>
	);
}

export default CartItem;
