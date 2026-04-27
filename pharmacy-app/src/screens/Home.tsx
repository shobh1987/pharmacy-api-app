
import { useNavigate } from 'react-router-dom';
import apiLogo from '../assets/api.png';

const API_URL = import.meta.env.VITE_APP_API_URL;

const Home = () => {
    const navigate = useNavigate();
    return (
        <div className="container-fluid">
      <section id="center">
        <div>
          <h1>Pharmacy Application</h1>
          <p>
            Welcome to the Pharmacy Application! GET | Add | Edit | Delete
          </p>
        </div>
        <button
          type="button"
          className="btn btn-primary mb-4"
          onClick={() => navigate('/medicines')}>
          Continue to explore the Application
        </button>
      </section>

      <div className="ticks"></div>

      <section id="next-steps">
        <div id="docs">
          <svg className="icon" role="presentation" aria-hidden="true">
            <use href="/icons.svg#documentation-icon"></use>
          </svg>
          <h2>Documentation</h2>
          <p>API Open ai </p>
          <ul>
            <li>
              <a href={`${API_URL}openapi/v1.json`} target="_blank">
                <img className="logo" src={apiLogo} alt="" />
                Explore Pharmacy API
              </a>
            </li>
          </ul>
        </div>
        <div id="social">
          <svg className="icon" role="presentation" aria-hidden="true">
            <use href="/icons.svg#social-icon"></use>
          </svg>
          <h2>Connect with us</h2>
          <p>Join the Pharmacy API community</p>
          <ul>
            <li>
              <a href="https://github.com/shobh1987/pharmacy-api-app" target="_blank">
                <svg
                  className="button-icon"
                  role="presentation"
                  aria-hidden="true"
                >
                  <use href="/icons.svg#github-icon"></use>
                </svg>
                GitHub
              </a>
            </li>
          </ul>
        </div>
      </section>
    </div>)
}

export default Home;