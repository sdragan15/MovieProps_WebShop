import styles from "../styles/login.css"
import { Link } from "react-router-dom"

function Register(){
    return <>
    <div className="login-container">
        <h1 className="header">Register</h1>
        <div className="login-form-wrapper">
            <form method="post">
                <table>
                    <tbody>
                    <tr>
                        <th>
                        <label>Username:</label>
                        </th>
                        <td>
                        <input type="text" name="username"></input>
                        </td>
                    </tr>
                    <tr>
                        <th>
                        <label>Email:</label>
                        </th>
                        <td>
                        <input type="text" name="email"></input>
                        </td>
                    </tr>
                    <tr>
                        <th>
                        <label>Password:</label>
                        </th>
                        <td>
                        <input type="password" name="password"></input>
                        </td>
                    </tr>
                    <tr>
                        <th>
                        <label>Name:</label>
                        </th>
                        <td>
                        <input type="text" name="name"></input>
                        </td>
                    </tr>
                    <tr>
                        <th>
                        <label>Last name:</label>
                        </th>
                        <td>
                        <input type="text" name="lastName"></input>
                        </td>
                    </tr>
                    <tr>
                        <th>
                        <label>Date of birth:</label>
                        </th>
                        <td>
                        <input type="date" name="birth"></input>
                        </td>
                    </tr>
                    <tr>
                        <th>
                        <label>Address:</label>
                        </th>
                        <td>
                        <input type="text" name="address"></input>
                        </td>
                    </tr>
                    </tbody>
                </table>
                <div className="submit-wrapper">
                    <button className="submit-btn">Register</button>
                </div>
            </form>
            <div className="register-wrapper">
                <Link to="/">Log in</Link>
            </div>
        </div>
    </div>
    </>
}

export default Register