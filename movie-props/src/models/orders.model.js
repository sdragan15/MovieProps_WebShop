export class OrdersModel {
	address = "";
	items = [];
	shipping = 0;
	products = 0;
	total = 0;
	ordered = new Date();
	delivered = new Date();
	orderType = new OrderType();
}

export class OrderType {
	ordered = 1;
	delivered = 2;
	canceled = 3;
}
