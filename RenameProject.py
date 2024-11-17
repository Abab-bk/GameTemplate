import os

def replace_string_in_file(file_name, search_string, replace_string):
    try:
        with open(file_name, 'r', encoding='utf-8') as file:
            content = file.read()
        
        content = content.replace(search_string, replace_string)
        
        with open(file_name, 'w', encoding='utf-8') as file:
            file.write(content)
        
        print(f"String '{search_string}' -> '{replace_string}' in '{file_name}'")
    except FileNotFoundError:
        print(f"File '{file_name}' not found.")
    except Exception as e:
        print(f"Error: {e}")

def rename_file(old_name, new_name):
    try:
        os.rename(old_name, new_name)
        print(f"File '{old_name}' renamed to '{new_name}'。")
    except FileNotFoundError:
        print(f"File '{old_name}' not found.")
    except Exception as e:
        print(f"Error when renaming: {e}")

def main():
    file_names = ["Src/MyNewGame.csproj", "Src/MyNewGame.sln", "Src/MyNewGame.sln.DotSettings.user"]
    project_name = input("input new project name: ")
    search_string = "MyNewGame"
    
    for file_name in file_names:
        if os.path.isfile(file_name):
            replace_string_in_file(file_name, search_string, project_name)
            rename_file(file_name, file_name.replace(search_string, project_name))
        else:
            print(f"文件 '{file_name}' 不在当前目录下。")
    
    if os.path.isfile("Src/project.godot"):
        replace_string_in_file("Src/project.godot", search_string, project_name)
        replace_string_in_file("Src/project.godot", search_string, project_name)

    input("Press Enter to exit...")

if __name__ == "__main__":
    main()