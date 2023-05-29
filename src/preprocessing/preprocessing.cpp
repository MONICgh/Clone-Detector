#include <bits/stdc++.h>
// #include <string_view>
// #include <vector>

namespace {

std::vector<std::string> split(const std::string &s, char delim) {
    std::vector<std::string> result;
    std::stringstream ss(s);
    std::string item;

    while (getline(ss, item, delim)) {
        result.emplace_back(item);
    }

    return result;
}

struct find_result {
  std::size_t line_id, lpos, rpos, new_start;
};

find_result parse_find(std::string_view s, std::size_t pos) {
  find_result result;

  while (s[pos - 1] != '[') {
      pos++;  
    }

    result.line_id = 0;
    while (s[pos] != ',') {
      result.line_id = result.line_id * 10 + (s[pos++] - '0');
    }

    pos += 2;

    result.lpos = 0;
    while (s[pos] != ']') {
      result.lpos = result.lpos * 10 + (s[pos++] - '0');
    }

    while (s[pos - 2] != ',') {
      pos++;
    }
    
    result.rpos = 0;
    while (s[pos] != ']') {
      result.rpos = result.rpos * 10 + (s[pos++] - '0');
    }

    result.new_start = pos;
    return result;
}

std::vector<std::string> normalize(const std::string& code) {
  std::ofstream out("parsing_input.txt");
    out << code << std::endl;
    auto code_lines = split(code, '\n');

    std::system("tree-sitter parse parsing_input.txt >parsing_output.txt");
    std::ifstream parsed("parsing_output.txt");
    std::stringstream buffer;
    buffer << parsed.rdbuf();
    auto res = buffer.str();
    std::vector<std::pair<std::string, find_result>> results;
    for (const auto& item : {"(identifier", "(string_literal", "(decimal_integer_literal"}) {
      std::string name = item;
      name.erase(name.begin());
      auto pos = res.find(item);
      while (pos != std::string::npos) {
        auto result = parse_find(res, pos);
        results.emplace_back(name, result);
        pos = res.find(item, result.new_start);
      }    
    }

    std::sort(results.begin(), results.end(), [](std::pair<std::string, find_result> a, std::pair<std::string, find_result> b) {
      return a.second.line_id > b.second.line_id || (a.second.line_id == b.second.line_id && a.second.lpos > b.second.lpos);
    });

    for (auto [item, result] : results) {
      code_lines[result.line_id].erase(result.lpos, result.rpos - result.lpos);
      code_lines[result.line_id].insert(result.lpos, item);
    }

    for (auto &line : code_lines) {
      line.erase(std::remove_if(line.begin(), line.end(), [](char x) { 
        return x == ' ' || x == '\t'; 
      }), line.end());
    }

    return code_lines;  
}

}


// file code, file out
int main (int argc, char* argv[]) {

  if (argc != 3) {
    std::cout << "Wrong arg!";
    exit(1);
  }

  std::string file_code = argv[1], file_out = argv[2];
  return 0;
}