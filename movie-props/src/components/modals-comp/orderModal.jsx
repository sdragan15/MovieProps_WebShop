import CartItem from "../myCart-comp/cartItem";

function OrderModal({ items, isOpen }) {
	const closeModal = (e) => {
		isOpen(false);
	};

	const stopPropagation = (event) => {
		event.stopPropagation();
	};

	return (
		<>
			<div className="order-modal-wrapper" onClick={closeModal}>
				<div className="order-modal-container" onClick={stopPropagation}>
					{items.map((item) => (
						<CartItem
							key={item.item.id}
							item={item.item}
							count={item.count}
							isOnlyShow={true}
						/>
					))}
				</div>
			</div>
		</>
	);
}

export default OrderModal;
