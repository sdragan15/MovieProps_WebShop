import styles from "../styles/login.css";
import { Link, useNavigate } from "react-router-dom";
import MyInput from "./input-comp/myInput";
import { useEffect, useState } from "react";
import UserService from "../services/user.service";
import { RegisterModel } from "../models/login.model";

function Register() {
  const navigate = useNavigate();
  const userService = new UserService();

  const [register, serRegister] = useState(new RegisterModel());
  const [image, setImage] = useState(null);
  const [imageUrl, setImageUrl] = useState();

  const handleSubmit = (event) => {
    event.preventDefault();

    if (register.email == "") {
      alert("E-mail is required");
      return;
    }
    if (register.password == "") {
      alert("Password is required");
      return;
    }
    if (register.name == "") {
      alert("Firstname is required");
      return;
    }
    if (register.lastname == "") {
      alert("Lastname is required");
      return;
    }
    if (register.address == "") {
      alert("Address is required");
      return;
    }

    const date = new Date(register.date);

    const formData = new FormData();
    formData.append("FirstName", register.name);
    formData.append("lastName", register.lastname);
    formData.append("email", register.email);
    formData.append("password", register.password);
    formData.append("address", register.address);
    formData.append("birthDay", register.date);
    formData.append("image", image);

    userService
      .register(formData)
      .then((response) => {
        if (response.status == 200) {
          alert("Success");
        } else {
          alert("Failed");
        }
      })
      .catch((error) => {
        console.log(error);
      });
    navigate("../login");
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

  return (
    <>
      <div className="register-container">
        <h1 className="header">Register</h1>
        <div className="register-form-wrapper">
          <form method="post" onSubmit={handleSubmit}>
            <MyInput
              text={"E-mail"}
              type={"text"}
              name={"e-mail"}
              value={register.email}
              onChange={(e) =>
                serRegister((prevState) => ({
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
                    serRegister((prevState) => ({
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
                    serRegister((prevState) => ({
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
                    serRegister((prevState) => ({
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
                    serRegister((prevState) => ({
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
                    serRegister((prevState) => ({
                      ...prevState,
                      lastname: e.target.value,
                    }))
                  }
                />
                <MyInput
                  text={"Date"}
                  type={"date"}
                  name={"date"}
                  value={register.date}
                  onChange={(e) =>
                    serRegister((prevState) => ({
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
