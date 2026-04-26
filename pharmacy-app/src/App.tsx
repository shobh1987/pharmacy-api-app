import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import heroImg from './assets/hero.png'
import './App.css'

const API_URL = import.meta.env.VITE_APP_API_URL;
console.log('API URL:', API_URL);

function App() {
  return (
    <>
      <section id="center">
        <div className="hero">
          <img src={heroImg} className="base" width="170" height="179" alt="" />
          <img src={reactLogo} className="framework" alt="React logo" />
          <img src={viteLogo} className="vite" alt="Vite logo" />
        </div>
        <div>
          <h1>Pharmacy Application</h1>
          <p>
            Welcome to the Pharmacy Application! GET | Add | Edit | Delete
          </p>
        </div>
        <button
          type="button"
          className="counter"
          onClick={() => window.open(`${API_URL}openapi/v1.json`, '_blank')}>
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
                <img className="logo" src={viteLogo} alt="" />
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

      <div className="ticks"></div>
      <section id="spacer"></section>
    </>
  )
}

export default App
