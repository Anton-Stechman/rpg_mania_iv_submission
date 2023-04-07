import utilities as util

def menu():
    util.menu_title("U3DT Main Menu")
    util.menu_option("1", "Git Menu", "Opens Git Menu")
    util.menu_option("2", "Code Menu", "Opens Code menu")
    util.menu_option("3", "Docs Menu", "Opens Docs Menu")
    util.menu_option("0", "Exit Menu", "closes main menu")
    response = util.get_response("Select an option: ")
    
    if (response == 1):
        util.open_menu("git")
    elif (response == 2):
        util.open_menu("code")
    elif (response == 3):
        util.open_menu("docs")
    else:
        util.clear()

util.clear()
menu()
