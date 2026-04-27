const NavBar = () => {
    return (<></>);

    return (
        <nav className="navbar">
            <div className="navbar-brand">
                <a className="navbar-item" href="/">
                    <h1 className="ml-2">Pharmacy System</h1>
                </a>
            </div>
            <div className="navbar-menu">
                <div className="navbar-start">
                    <a className="navbar-item" href="/medicines">Medicines</a>
                </div>
                <div className="navbar-end">
                    <div className="navbar-item">
                        <div className="buttons">
                            <a className="button is-primary" href="/">
                                <strong>Sign up</strong>
                            </a>
                            <a className="button is-light" href="/">
                                Sign in
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </nav>
    );
}

export default NavBar;