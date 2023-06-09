import React, { Component } from "react";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import "../index.css";
class Toastr extends Component {
	render() {
		return (
			<div>
				<ToastContainer />
			</div>
		);
	}
}
export default Toastr;
