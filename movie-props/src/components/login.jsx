import styles from "../styles/login.css";
import { Link, useNavigate } from "react-router-dom";

function Login() {
  const navigate = useNavigate();

  const handleSubmit = (event) => {
    event.preventDefault();
    navigate("/dashboard");
  };

  return (
    <>
      <div className="login-container">
        <h1 className="header">Log in</h1>
        <div className="login-form-wrapper">
          <form method="post" onSubmit={handleSubmit}>
            <table>
              <tbody>
                <tr>
                  <th>
                    <label>e-mail:</label>
                  </th>
                  <td>
                    <input type="text" name="email"></input>
                  </td>
                </tr>
                <tr>
                  <th>
                    <label>password:</label>
                  </th>
                  <td>
                    <input type="password" name="password"></input>
                  </td>
                </tr>
              </tbody>
            </table>
            <div className="submit-wrapper">
              <button className="submit-btn">Log in</button>
            </div>
          </form>
          <div className="register-wrapper">
            <Link to="/register">Not registered?</Link>
          </div>
        </div>
      </div>
    </>
  );
}

export default Login;
