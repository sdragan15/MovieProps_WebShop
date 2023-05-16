import styles from "../styles/login.css"
import { Link } from "react-router-dom"

function Login(){
    return <>
    <div className="login-container">
        <h1 className="header">Log in</h1>
        <div className="login-form-wrapper">
            <form method="post">
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
}

export default Login