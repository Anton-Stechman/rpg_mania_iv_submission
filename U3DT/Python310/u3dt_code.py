import utilities as util

def menu():
    util.menu_title("U3DT Main Menu")
    util.menu_option("1", "git menu", "opens git managment menu")
    util.menu_option("2", "code menu", "opens code menu")
    util.menu_option("3", "docs menu", "opens deocs menu")
    util.menu_option("0", "exit menu", "closes main menu")
    response = util.get_response("Select an option: ")
    util.clear()

util.clear()
menu()