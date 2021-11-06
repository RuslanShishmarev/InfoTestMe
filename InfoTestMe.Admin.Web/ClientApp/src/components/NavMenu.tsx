import * as React from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export default class NavMenu extends React.PureComponent<{}, { isOpen: boolean, isAuth: boolean }> {
    public state = {
        isOpen: false,
        isAuth: false
    };

    public render() {
        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3" light>
                    <Container>
                        <NavbarBrand tag={Link} to="/">InfoTestMe</NavbarBrand>
                        <NavbarToggler onClick={this.toggle} className="mr-2"/>
                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={this.state.isOpen} navbar>
                        {
                                sessionStorage.getItem('token') == null || this.state.isAuth ?
                                    <ul className="navbar-nav flex-grow">
                                        <NavItem>
                                            <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                                        </NavItem>
                                        <NavItem>
                                            <NavLink tag={Link} className="text-dark" to="/singin">SingIn</NavLink>
                                        </NavItem>
                                        <NavItem>
                                            <NavLink tag={Link} className="text-dark" to="/register">Register</NavLink>
                                        </NavItem>
                                    </ul>
                                    :
                                    <ul className="navbar-nav flex-grow">
                                        <NavItem>
                                            <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                                        </NavItem>
                                        <NavItem>
                                            <NavLink tag={Link} className="text-dark" to="/mypage">MyPage</NavLink>
                                        </NavItem>
                                        <NavItem>
                                            <NavLink tag={Link} className="text-dark" onClick={() => {                                                
                                                this.singOut();
                                                }
                                            } to="/singin">SingOut</NavLink>
                                        </NavItem>
                                    </ul>
                         }
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        );
    }

    private toggle = () => {
        this.setState({
            isOpen: !this.state.isOpen
        });
    }

    private singOut = () => {
        sessionStorage.clear();        
        this.setState({
            isAuth: false
        });
        window.location.replace(`/singin`);
    }

}
