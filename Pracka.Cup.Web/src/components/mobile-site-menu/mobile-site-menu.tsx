import React from 'react'
import { Link } from 'react-router-dom'
import AppBar from '@material-ui/core/AppBar'
import Toolbar from '@material-ui/core/Toolbar'
import Typography from '@material-ui/core/Typography'
import useScrollTrigger from '@material-ui/core/useScrollTrigger'
import Container from '@material-ui/core/Container'
import Slide from '@material-ui/core/Slide'

import { index as leagueRanksIndex } from '../../routes/league-rank-routes'
import { index as organizeGameIndex } from '../../routes/organize-game-routes'
import { index as gameResultsIndex } from '../../routes/game-results-routes'
import { index as userStatsIndex } from '../../routes/user-stats-routes'
import { index as historyIndex } from '../../routes/history-routes'

import { makeStyles, withStyles } from '@material-ui/core/styles';
import Menu, { MenuProps } from '@material-ui/core/Menu';
import MenuItem from '@material-ui/core/MenuItem';
import { Button } from '@material-ui/core'
import { SiteMenuProps } from '../types'
import { BurgerMenuIcon } from '../icons'

const StyledMenu = withStyles({
  paper: {
    border: '1px solid #d3d4d5',
  },
})((props: MenuProps) => (
  <Menu
    elevation={0}
    getContentAnchorEl={null}
    anchorOrigin={{
      vertical: 'bottom',
      horizontal: 'center',
    }}
    transformOrigin={{
      vertical: 'top',
      horizontal: 'center',
    }}
    {...props}
  />
));

const StyledMenuItem = withStyles((theme) => ({
  root: {
    color: 'midnightblue',
    '&:focus': {
      backgroundColor: 'darkgrey',
      '& .MuiListItemIcon-root, & .MuiListItemText-primary': {
        color: theme.palette.common.white,
      },
    },
  },
}))(MenuItem);


interface Props {
  /**
   * Injected by the documentation to work in an iframe.
   * You won't need it on your project.
   */
  window?: () => Window;
  children: React.ReactElement;
}

function HideOnScroll(props: Props) {
  const { children, window } = props;
  // Note that you normally won't need to set the window ref as useScrollTrigger
  // will default to window.
  // This is only being set here because the demo is in an iframe.
  const trigger = useScrollTrigger({ target: window ? window() : undefined });

  return (
    <Slide appear={false} direction="down" in={!trigger}>
      {children}
    </Slide>
  );
}

function MobileSiteMenuButton(props: SiteMenuProps) {
  const {
    options,
    classes
  } = props
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);

  const handleClick = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <>
      <Button
        aria-controls="customized-menu"
        aria-haspopup="true"
        variant="contained"
        color="primary"
        onClick={handleClick}
        classes={{
          root: classes?.root,
          containedPrimary: classes?.containedPrimary
        }}
      >
        <BurgerMenuIcon
          style={{
            height: '1.75em'
          }}
        />
      </Button>
      <StyledMenu
        id="customized-menu"
        anchorEl={anchorEl}
        keepMounted
        open={Boolean(anchorEl)}
        onClose={handleClose}
      >
        {options.map(({ label, linkTo }) => {
          return (
            <StyledMenuItem key={label}>
              <Link to={linkTo} className={classes?.link}>{label}</Link>
            </StyledMenuItem>
          )
        })}
      </StyledMenu>
    </>
  )
}

const useStyles = makeStyles((theme) => {
  return {
    menuButtonPosition: {
      position: 'relative',
      left: '2.5%',
      padding: '0',
    },
    menuButtonColor: {
      backgroundColor: 'lightgrey',
      '&:hover': {
        backgroundColor: 'darkgray',
      }
    },
    menuItemLink: {
      textDecoration: 'none',
      width: '100%',
      color: 'midnightblue',
    },
    title: {
      position: 'relative',
      left: '20%',
      fontSize: '2em'
    }
  }
})

export default function MobileMenu(props: Props) {
  const classes = useStyles()

  return (
    <React.Fragment>
      <HideOnScroll {...props}>
        <AppBar>
          <Toolbar>
            <MobileSiteMenuButton
              classes={{
                root: classes.menuButtonPosition,
                containedPrimary: classes.menuButtonColor,
                link: classes.menuItemLink
              }}
              options={[
                { label: 'User stats', linkTo: userStatsIndex },
                { label: 'History', linkTo: historyIndex },
                { label: 'League ranks', linkTo: leagueRanksIndex },
                { label: 'New game', linkTo: organizeGameIndex },
                { label: 'Game results', linkTo: gameResultsIndex },
              ]}
            />
            <Typography
              variant="h6"
              className={classes.title}
            >
              Pracka-Cup
            </Typography>
          </Toolbar>
        </AppBar>
      </HideOnScroll>
      <Toolbar />
      <Container>
        {props.children}
      </Container>
    </React.Fragment>
  );
}
