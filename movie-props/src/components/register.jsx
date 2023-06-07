import styles from "../styles/login.css";
import { Link, useNavigate } from "react-router-dom";
import MyInput from "./input-comp/myInput";
import { useEffect, useState } from "react";

function Register() {
  const navigate = useNavigate();

  const [image, setImage] = useState(null);
  const [imageUrl, setImageUrl] = useState();

  const handleSubmit = (event) => {
    event.preventDefault();
    navigate("/dashboard");
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
            <MyInput text={"E-mail"} type={"text"} name={"e-mail"} />
            <div className="register-inputs">
              <div>
                <MyInput text={"Username"} type={"text"} name={"username"} />
                <MyInput text={"Name"} type={"text"} name={"name"} />
                <MyInput text={"Address"} type={"text"} name={"address"} />
                <img className="register-img" src={imageUrl}></img>
              </div>
              <div>
                <MyInput
                  text={"Password"}
                  type={"password"}
                  name={"password"}
                />
                <MyInput text={"Last name"} type={"text"} name={"lastName"} />
                <MyInput text={"Date"} type={"date"} name={"date"} />
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
            <Link to="dashboard">Log in</Link>
          </div>
        </div>
      </div>
      <img className="login-photo" src={require("../images/lotrRing.png")} />
    </>
  );
}

export default Register;
